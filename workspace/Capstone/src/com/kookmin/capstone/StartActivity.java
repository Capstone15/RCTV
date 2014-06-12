package com.kookmin.capstone;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class StartActivity extends Activity {
	private Button btn_join, btn_login;
	private boolean mFlag = false;
	private EditText ed_id, ed_pass;
	static Handler backhandler, toasthandler;
	private String id, password;
	private String connString = "jdbc:jtds:sqlserver://203.246.112.87:49304;databaseName=rctv";

	private AsyncTask<String, String, String> mTask;
	Message msg;
	ArrayList<String> list;
	ArrayAdapter<String> adapter;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_start);

		btn_join = (Button) findViewById(R.id.btn_join);
		btn_login = (Button) findViewById(R.id.btn_login);
		ed_id = (EditText) findViewById(R.id.edt_loginid);
		ed_pass = (EditText) findViewById(R.id.edt_loginpass);

		list = new ArrayList<String>();

		adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, list);
		
		SharedPreferences cache = getSharedPreferences("cache", Activity.MODE_PRIVATE);
		ed_id.setText(cache.getString("id", null));
		ed_pass.setText(cache.getString("pass",null));
		
		// toast를 띄우기 위한 handler
		toasthandler = new Handler() {
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				Toast toast = Toast.makeText(getApplicationContext(),
						(CharSequence) msg.obj, Toast.LENGTH_SHORT);
				toast.setGravity(Gravity.CENTER, 0, 100);
				toast.show();
			}
		};
		btn_login.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {

				// //text용
				// Intent intent = new Intent(StartActivity.this,
				// MainActivity.class);
				// startActivity(intent);

				id = ed_id.getText().toString();
				password = ed_pass.getText().toString();

				if (password.equals("")) {
					msg = toasthandler.obtainMessage(1, "비번을 입력 해 주세요");

					if (id.equals(""))
						msg = toasthandler.obtainMessage(1, "아이디를 입력 해 주세요");
					toasthandler.sendMessage(msg);

				} else if (id.equals("")) {
					msg = toasthandler.obtainMessage(1, "아이디를 입력 해 주세요");
					toasthandler.sendMessage(msg);
				} else
					mTask = new MyAsyncTask().execute();
			}
		});

		btn_join.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				// 아이디와 비번 확인
				Intent intent = new Intent(StartActivity.this,
						JoinActivity.class);
				startActivity(intent);
			}
		});
		backhandler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				if (msg.what == 0)
					mFlag = false;
			}
		};
	}

	public void query() {
		Connection conn = null;
		try {
			Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
			conn = DriverManager.getConnection(connString, "sa", "22179215");
			
			Statement stmt = conn.createStatement();
			ResultSet reset;
			Log.d("check", "연결확인");
			int count = 0;
			reset = stmt
					.executeQuery("SELECT COUNT(*) FROM customer WHERE ID = '"
							+ id + "'");
			while (reset.next())
				count = reset.getInt(1);
			if (count == 0) {
				msg = toasthandler.obtainMessage(1, "아이디를 확인해주세요");
				toasthandler.sendMessage(msg);
			} else {
				reset = stmt
						.executeQuery("SELECT COUNT(*) FROM customer WHERE ID = '"
								+ id + "' AND Password = '" + password + "'");
				while (reset.next())
					count = reset.getInt(1);

				if (count > 0) {
					String intent_ip = null, intent_port = null, intent_port2 = null;
					String query = "FROM customer C, raspberrypi A WHERE C.RCTVnumber=A.RaspNumber AND C.ID = '" + id + "'";
					reset = stmt.executeQuery("SELECT A.RaspIP " + query);
					while (reset.next())
						intent_ip = reset.getString("RaspIP");

					reset = stmt.executeQuery("SELECT A.imgPort " + query);
					while (reset.next())
						intent_port = reset.getString("imgPort");

					reset = stmt.executeQuery("SELECT A.chatPort " + query);
					while (reset.next())
						intent_port2 = reset.getString("chatPort");

					Log.d("check", "ID : " + intent_ip + ", PORT : "
							+ intent_port + ", PORT2 : " + intent_port2);
					
					SharedPreferences cache = getSharedPreferences("cache", Activity.MODE_PRIVATE);
					SharedPreferences.Editor editor = cache.edit();
					editor.putString("id", id);
					editor.putString("pass", password);
					editor.commit();

					
					Intent intent = new Intent(StartActivity.this,
							MainActivity.class);
					intent.putExtra("IP", intent_ip);
					intent.putExtra("PORT", intent_port);
					intent.putExtra("PORT2", intent_port2);
					intent.putExtra("ID", id.toString());
					startActivity(intent);
					
				} else {
					msg = toasthandler.obtainMessage(1, "비밀번호를 확인해주세요");
					toasthandler.sendMessage(msg);
				}
			}
			conn.close();
		} catch (Exception e) {
			Log.w("Error connection", e.getMessage());
		}
	}

	@Override
	public void onBackPressed() {

		if (!mFlag) {
			Toast.makeText(StartActivity.this, "'뒤로'버튼을 한번 더 누르시면 종료됩니다.",
					Toast.LENGTH_SHORT).show();
			mFlag = true;
			backhandler.sendEmptyMessageDelayed(0, 1000 * 2);
		} else
			android.os.Process.killProcess(android.os.Process.myPid());
	}

	// 아래함수가 중요
	public class MyAsyncTask extends AsyncTask<String, String, String> {
		// @Override
		protected void onPreExecute() {
		}

		// @Override
		protected String doInBackground(String... params) {
			if (isCancelled())
				return (null); // don't forget to terminate this method
			query();
			return null;
		}

		// @Override
		protected void onPostExecute(String result) {
		}

		// @Override
		protected void onCancelled() {
			super.onCancelled();
		}
	}

}
