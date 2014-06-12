package com.kookmin.capstone;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.Color;
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
import android.widget.TextView;
import android.widget.Toast;

public class JoinActivity extends Activity {
	ArrayList<String> list;
	ArrayAdapter<String> adapter;

	private AsyncTask<String, String, String> mTask;

	private Button btn_id_check, btn_num_check, btn_join;
	private EditText edt_id, edt_password, edt_password_check, edt_name,
			edt_birth, edt_pronumber;
	private TextView view_check;
	private String id, pw, pw_check, name, birth, pronum;
	private String connString = "jdbc:jtds:sqlserver://203.246.112.87:49304;databaseName=rctv";

	private int K = 0;
	private Message msg;
	private Handler toasthandler;
	private Boolean id_flag = false, pw_flag = false, name_flag = false,
			pro_flag = false;
	private Boolean flag = false;

	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_join);

		btn_id_check = (Button) findViewById(R.id.btn_id_check);
		btn_num_check = (Button) findViewById(R.id.btn_num_check);
		btn_join = (Button) findViewById(R.id.btn_join);

		edt_id = (EditText) findViewById(R.id.edt_join_id);
		edt_password = (EditText) findViewById(R.id.edt_join_password);
		edt_password_check = (EditText) findViewById(R.id.edt_join_pwCheck);
		edt_name = (EditText) findViewById(R.id.edt_join_name);
		edt_birth = (EditText) findViewById(R.id.edt_join_birth);
		edt_pronumber = (EditText) findViewById(R.id.edt_join_pronum);

		view_check = (TextView) findViewById(R.id.view_pwCheckMsg);
		list = new ArrayList<String>();

		adapter = new ArrayAdapter<String>(this,
				android.R.layout.simple_list_item_1, list);
		String colors = "#FFFFFF";
		edt_id.setTextColor(Color.parseColor(colors));
		edt_password.setTextColor(Color.parseColor(colors));
		edt_password_check.setTextColor(Color.parseColor(colors));
		edt_name.setTextColor(Color.parseColor(colors));
		edt_birth.setTextColor(Color.parseColor(colors));
		edt_pronumber.setTextColor(Color.parseColor(colors));
		
		
		toasthandler = new Handler() {
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				Toast toast = Toast.makeText(getApplicationContext(),
						(CharSequence) msg.obj, Toast.LENGTH_SHORT);
				toast.setGravity(Gravity.CENTER, 0, 100);
				toast.show();
			}
		};
		edt_id.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				if (hasFocus)
					id_flag = false;
			}
		});
		edt_password.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				if (!hasFocus) {
					pw = edt_password.getText().toString();
					pw_check = edt_password_check.getText().toString();
					if (pw.equals("")) {
						pw_flag = false;
						view_check.setText("");
					} else if (pw.equals(pw_check)) {
						pw_flag = true;
						view_check.setText("일치");
					} else {
						pw_flag = false;
						view_check.setText("불일치");
					}
				}

			}
		});
		edt_password_check
				.setOnFocusChangeListener(new View.OnFocusChangeListener() {
					@Override
					public void onFocusChange(View v, final boolean hasFocus) {
						if (!hasFocus) {
							pw = edt_password.getText().toString();
							pw_check = edt_password_check.getText().toString();

							if (pw.equals(pw_check)) {
								view_check.setText("일치");
								pw_flag = true;
							} else if (pw_check.equals("")) {
								view_check.setText("");
								pw_flag = false;
							} else {
								view_check.setText("불일치");
								pw_flag = false;
							}
						}

					}
				});
		edt_name.setOnFocusChangeListener(new View.OnFocusChangeListener() {
			@Override
			public void onFocusChange(View v, boolean hasFocus) {
				if (!hasFocus) {
					if (edt_name.getText().toString().equals(""))
						name_flag = false;
					else
						name_flag = true;
				}
			}
		});
		edt_pronumber
				.setOnFocusChangeListener(new View.OnFocusChangeListener() {
					@Override
					public void onFocusChange(View v, boolean hasFocus) {
						if (hasFocus)
							pro_flag = false;
					}
				});
		btn_id_check.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				id = edt_id.getText().toString();
				Log.d("check ID", id);
				if (id.equals("")) {
					msg = toasthandler.obtainMessage(1, "ID 입력해주세요");
					toasthandler.sendMessage(msg);
					id_flag = false;
				} else {
					K = 0;
					mTask = new MyAsyncTask().execute();
				}
			}
		});
		btn_num_check.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				K = 1;
				pronum = edt_pronumber.getText().toString();
				Log.d("check Pronum", pronum);
				mTask = new MyAsyncTask().execute();
			}
		});

		btn_join.setOnClickListener(new View.OnClickListener() {
			@Override
			public void onClick(View v) {
				id = "'" + edt_id.getText().toString() + "'";
				pw = "'" + edt_password.getText().toString() + "'";
				name = "'" + edt_name.getText().toString() + "'";
				birth = "'" + edt_birth.getText().toString() + "'";
				pronum = "'" + edt_pronumber.getText().toString() + "'";
				K = 2;
				if (!id_flag) {
					msg = toasthandler.obtainMessage(1, "ID 중복버튼을 눌러주세요");
					toasthandler.sendMessage(msg);
				} else if (!pw_flag) {
					msg = toasthandler.obtainMessage(1, "비번을 확인해주세요.");
					toasthandler.sendMessage(msg);
				} else if (!pro_flag) {
					msg = toasthandler.obtainMessage(1, "제품번호를 확인해주세요");
					toasthandler.sendMessage(msg);
				} else if (!name_flag) {
					msg = toasthandler.obtainMessage(1, "이름을 입력해주세요");
					toasthandler.sendMessage(msg);
				} else {
					Log.d("check join", id + ", " + pw + ", " + name + ", "
							+ birth + ", " + pronum);
					mTask = new MyAsyncTask().execute();

					try {
						Thread.sleep(3000);
					} catch (InterruptedException e) {
						e.printStackTrace();
					}
					if (flag)
						dialog();
					
				}

			}
		});
	}

	public void query_checkId() {
		Connection conn = null;
		try {
			Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
			conn = DriverManager.getConnection(connString, "sa", "22179215");

			Statement stmt = conn.createStatement();
			ResultSet reset = stmt
					.executeQuery("SELECT COUNT(*) FROM customer WHERE ID = '"
							+ id + "'");
			int count = 0;
			while (reset.next())
				count = reset.getInt(1);
			
			if (count > 0) {
				msg = toasthandler.obtainMessage(1, "이미 있는 ID입니다.");
				id_flag = false;

			} else {
				msg = toasthandler.obtainMessage(1, "사용 할 수 있는 ID입니다.");
				id_flag = true;
			}
			toasthandler.sendMessage(msg);
			conn.close();
		} catch (Exception e) {
			Log.w("Error connection", "query checkId        " + e.getMessage());
			msg = toasthandler.obtainMessage(1, "서버와 연결 할 수 없습니다.");
			toasthandler.sendMessage(msg);
		}
	}

	public void query_checkNum() {
		Connection conn = null;
		try {
			Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
			conn = DriverManager.getConnection(connString, "sa", "22179215");
			Statement stmt = conn.createStatement();

			ResultSet reset = stmt
					.executeQuery("SELECT COUNT(*) FROM raspberrypi WHERE RaspNumber = '"
							+ pronum + "'");

			int count = 0;
			while (reset.next()) {
				count = reset.getInt(1);
			}
			if (count > 0) {
				msg = toasthandler.obtainMessage(1, "등록된 제품번호입니다.");
				pro_flag = true;
			} else {
				msg = toasthandler.obtainMessage(1, "등록 되지 않은 제품번호입니다.");
				pro_flag = false;
			}
			toasthandler.sendMessage(msg);
			conn.close();
		} catch (Exception e) {
			Log.w("Error connection", "query checkProNum " + e.getMessage());
			msg = toasthandler.obtainMessage(1, "서버와 연결 할 수 없습니다.");
			toasthandler.sendMessage(msg);
		}
	}

	public void query_join() {
		Connection conn = null;
		try {

			Class.forName("net.sourceforge.jtds.jdbc.Driver").newInstance();
			conn = DriverManager.getConnection(connString, "sa", "22179215");

			Statement stmt = conn.createStatement();
				stmt.executeUpdate("INSERT INTO customer (ID, Password, Name, BirthDate,RCTVNumber) VALUES ("
						+ id
						+ ","
						+ pw
						+ ","
						+ name
						+ ","
						+ birth
						+ ","
						+ pronum
						+ ")");
			Log.d("check", "insert 성공");

			conn.close();
			flag = true;
		} catch (Exception e) {
			Log.w("Error connection", "query insert  " + e.getMessage());
			msg = toasthandler.obtainMessage(1, "서버와 연결 할 수 없습니다.");
			toasthandler.sendMessage(msg);
		}
	}

	private void dialog() {
		AlertDialog.Builder dialog = new AlertDialog.Builder(JoinActivity.this);
		dialog.setTitle("가입에 성공하였습니다.");
		dialog.setPositiveButton(R.string.dialog_ok,
				new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
						finish();
					}
				}).create();
		dialog.show();

	}

	public class MyAsyncTask extends AsyncTask<String, String, String> {
		// @Override
		protected void onPreExecute() {
		}

		// @Override
		protected String doInBackground(String... params) {
			if (isCancelled())
				return (null); // don't forget to terminate this method

			switch (K) {
			case 0:
				query_checkId();
				break;
			case 1:
				query_checkNum();
				break;
			case 2:
				query_join();
				break;
			default:
				break;
			}
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

	@Override
	public void onBackPressed() {
		finish();
	}

}