package com.kookmin.capstone;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintStream;
import java.net.Socket;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Locale;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Bitmap.CompressFormat;
import android.graphics.BitmapFactory;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v4.view.ViewPager.OnPageChangeListener;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MotionEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ImageView.ScaleType;
import android.widget.ScrollView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends Activity implements OnClickListener {

	private Button btn_left, btn_right, btn_picture, btn_connect,
			btn_disconnect, btn_send, btn_one, btn_two;
	private ImageView view_pi;
	private TextView txt_chat;
	private EditText ed_msg;
	private ScrollView scrollview;
	private Socket socket, csocket;
	private PrintStream toServer, toServer2;
	private BufferedReader fromServer2;
	private ViewPager mPager;
	private String intent_ip, intent_port, intent_port2, intent_id;
	private Bitmap bitmap;

	private boolean pic_flag = false, chat_flag = false, sock_flag = false,
			btnDown_flag = false, toast_flag = false, master_flag = false;
	static Handler mhandler, toasthandler, backhandler, txthandler,
			dialoghandler, initalhandler;

	// private Calendar calendar;

	@Override
	public void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		setLayout();

		mPager = (ViewPager) findViewById(R.id.pager);
		mPager.setAdapter(new myPagerAdapter(this));
		mPager.setOnPageChangeListener(new OnPageChangeListener() {
			@Override
			public void onPageSelected(int position) {
			}

			@Override
			public void onPageScrolled(int arg0, float arg1, int arg2) {
			}

			@Override
			public void onPageScrollStateChanged(int state) {
				if (state == mPager.SCROLL_STATE_IDLE) {
					// 원하는 페이지에 맞게 조건
					InputMethodManager im = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
					im.hideSoftInputFromWindow(mPager.getWindowToken(), 0);
				}

			}
		});

		Intent i = getIntent();
		intent_ip = i.getStringExtra("IP");
		intent_port = i.getStringExtra("PORT");
		intent_port2 = i.getStringExtra("PORT2");
		intent_id = i.getStringExtra("ID");

		// new Thread(new Runnable() {
		// public void run() {
		// connect(intent_ip, Integer.parseInt(intent_port));
		//
		// }
		// }).start();
		MyCctvThread ct = new MyCctvThread();
		ct.start();
		MyChatThread th = new MyChatThread();
		th.start();

		toasthandler = new Handler() {
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				Toast.makeText(getApplicationContext(), (CharSequence) msg.obj,
						Toast.LENGTH_SHORT).show();
			}
		};
		dialoghandler = new Handler() {
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				dialog(msg.toString());
			}
		};
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	class MyChatThread extends Thread implements Runnable {
		public MyChatThread() {
		}

		public void run() {
			try {
				Thread.sleep(3000);
				Log.d("check", "chat Start");
				if (chat_flag) {
					Log.d("check", "chatSocket Connect Success");
					String chat_msg = null;
					String com_msg = "__";
					sendChatMsg(intent_id + " 입장.");
					while ((chat_msg = fromServer2.readLine()) != null) {
						Log.d("check chat", chat_msg);

						Message msg = txthandler.obtainMessage(1, chat_msg);
						if (chat_msg.toString().equals("__mc")) {
							master_flag = true;
							Log.d("check", "MC");
							msg = txthandler.obtainMessage(1, "권한 획득");
							txthandler.sendMessage(msg);
						} else {
							if (!chat_msg.toString().startsWith(com_msg)){
								txthandler.sendMessage(msg);
								Log.d("check", "NOT");
							}
							
						}
					}
					chat_flag = false;
					master_flag = false;
				}
			} catch (Exception ex) {
				ex.printStackTrace();
				chat_flag = false;
				master_flag = false;
			}
		}
	}

	public void SaveBitmapToFileCache(Bitmap bitmap, String strFilePath,
			String filename) {

		File file = new File(strFilePath);
		// If no folders
		if (!file.exists()) {
			file.mkdirs();
			// Toast.makeText(this, "Success", Toast.LENGTH_SHORT).show();
		}
		File fileCacheItem = new File(strFilePath + filename);
		OutputStream out = null;

		try {
			fileCacheItem.createNewFile();
			out = new FileOutputStream(fileCacheItem);
			bitmap.compress(CompressFormat.JPEG, 100, out);
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			try {
				out.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}

	class MyCctvThread extends Thread implements Runnable {
		public MyCctvThread() {
		}

		public void run() {
			String ip = intent_ip;
			int port = Integer.parseInt(intent_port);
			int port2 = Integer.parseInt(intent_port2);
			int start = 0;

			BitmapFactory.Options option = new BitmapFactory.Options();
			option.inPurgeable = true;
			option.inDither = true;

			try {
				
				socket = new Socket(ip, port);
				csocket = new Socket(ip, port2);
				toServer2 = new PrintStream(csocket.getOutputStream(), true,
						"UTF-8");
				fromServer2 = new BufferedReader(new InputStreamReader(
						csocket.getInputStream(), "UTF-8"));
				InputStream in = socket.getInputStream();

				chat_flag = true;
				sock_flag = true;

				Message msg = txthandler.obtainMessage(1, "연결 성공.");
				txthandler.sendMessage(msg);

				Log.d("check", "cctvSocket Connect Success");
				toServer = new PrintStream(socket.getOutputStream(), true,
						"UTF-8");

				byte buf[] = new byte[4];
				int len = 0;
				byte[] pic;
				while (true) {

					in.read(buf);
					try {
						len = Endian.getBigEndian(buf);
					} catch (Exception e) {
						e.printStackTrace();
						continue;
					} // picamera FileSize

					// s = in.read(buf);
					// if (s == -1)
					// break;
					// len = Integer.parseInt((new String(buf)));

					pic = new byte[len];
					pic = read_data(in, len);
					bitmap = BitmapFactory.decodeByteArray(pic, 0, len, option);
					if (pic_flag) {
						SimpleDateFormat mSimpleDateFormat = new SimpleDateFormat(
								"yyyy.MM.dd HH:mm:ss", Locale.KOREA);
						Date currentTime = new Date();
						String mTime = mSimpleDateFormat.format(currentTime)
								+ ".png";
						String dir = "/mnt/sdcard/Pictures/Cctvpic/";
						SaveBitmapToFileCache(bitmap, dir, mTime);
						pic_flag = false;
						msg = toasthandler.obtainMessage(1, "저장 완료");
						toasthandler.sendMessage(msg);
						Log.d("check", dir);
					}
					Message img = new Message();
					img.obj = bitmap;
					mhandler.sendMessage(img);

				}
			} catch (Exception ex) {
				ex.printStackTrace();
			}
			if(!sock_flag)
				close_socket();
			if (!toast_flag) {
				Message msg = txthandler.obtainMessage(1, "연결 끊김.");
				txthandler.sendMessage(msg);
			}
			toast_flag = false;
		}
	}

	private class TouchThread extends Thread {
		String move = null;

		public TouchThread(String k) {
			move = k;
		}

		@Override
		public void run() {
			super.run();
			while (btnDown_flag) {
				sendMsg(move);
				try {
					Thread.sleep(1500);
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			}
		}
	}

	private void sendChatMsg(String msg) {
		if (sock_flag) {
			toServer2.print(msg);
			toServer2.flush();
			Log.d("check", "Chat send : " + msg);
		}
	}

	private void sendMsg(String msg) {
		if (sock_flag) {
			toServer2.print(msg);
			toServer2.flush();
		}
		Log.d("check", "Move send : " + msg);
	}

	private void close_socket() {
		try {
			if (sock_flag) {
				sendChatMsg(intent_id + " 종료.");
				sendChatMsg("__quit");
				Thread.sleep(1000);
				socket.close();
				csocket.close();
				chat_flag = false;
				sock_flag = false;
				master_flag = false;
			}
		} catch (IOException e) {
			e.printStackTrace();
		} catch (InterruptedException e) {
			e.printStackTrace();
		}
		Message msg = initalhandler.obtainMessage(1, "");
		initalhandler.sendMessage(msg);
	}

	@Override
	public void onBackPressed() {
		try {
			if (sock_flag) {
				sendChatMsg(intent_id + " 종료.");
				sendChatMsg("__quit");
				socket.close();
				csocket.close();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
		finish();
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		close_socket();
	}

	
	private void dialog(String msg) {

		AlertDialog.Builder dialog = new AlertDialog.Builder(MainActivity.this);
		dialog.setTitle("연결이 끊어졌습니다.");
		dialog.setPositiveButton(R.string.dialog_ok,
				new DialogInterface.OnClickListener() {
					public void onClick(DialogInterface dialog, int whichButton) {
					}
				}).create();
		dialog.show();
	}

	private void setCurrentInflateItem(int type) {
		if (type == 0) {
			mPager.setCurrentItem(0);
		} else if (type == 1) {
			mPager.setCurrentItem(1);
		} else {
			mPager.setCurrentItem(2);
		}
	}

	/**
	 * Layout
	 */

	private void setLayout() {

		btn_one = (Button) findViewById(R.id.btn_one);
		btn_two = (Button) findViewById(R.id.btn_two);
		btn_one.setOnClickListener(this);
		btn_two.setOnClickListener(this);
	}

	/**
	 * PagerAdapter
	 */
	public class myPagerAdapter extends PagerAdapter {

		private LayoutInflater mInflater;

		public myPagerAdapter(Context context) {
			super();
			mInflater = LayoutInflater.from(context);
		}

		public int getCount() {
			return 2;
		}

		public Object instantiateItem(View pager, int position) {
			View v = null;

			switch (position) {
			case 0:
				v = mInflater.inflate(R.layout.inflate_cctv, null);
				btn_connect = (Button) v.findViewById(R.id.btn_connect);
				btn_disconnect = (Button) v.findViewById(R.id.btn_dissconnect);
				btn_left = (Button) v.findViewById(R.id.btn_left);
				btn_right = (Button) v.findViewById(R.id.btn_right);
				btn_picture = (Button) v.findViewById(R.id.btn_picture);
				view_pi = (ImageView) v.findViewById(R.id.view_pi);
				view_pi.setScaleType(ScaleType.CENTER_CROP);

				btn_picture.setOnClickListener(new View.OnClickListener() {
					@Override
					public void onClick(View v) {
						pic_flag = true;

					}
				});
				btn_connect.setOnClickListener(new View.OnClickListener() {
					@Override
					public void onClick(View v) {
						if (!sock_flag) {
							MyCctvThread ct = new MyCctvThread();
							ct.start();
							MyChatThread th = new MyChatThread();
							th.start();
						}
						Log.d("check", "Thread_start");
					}
				});
				btn_disconnect.setOnClickListener(new View.OnClickListener() {
					@Override
					public void onClick(View v) {
						if (sock_flag) {
							toast_flag = true;
							close_socket();
							Message msg = txthandler.obtainMessage(1, "연결 종료.");
							txthandler.sendMessage(msg);

							MyCctvThread.interrupted();
							MyChatThread.interrupted();
						}
					}
				});
				btn_left.setOnTouchListener(new View.OnTouchListener() {
					@Override
					public boolean onTouch(View v, MotionEvent event) {
						if (master_flag) {
							switch (event.getAction()) {
							case MotionEvent.ACTION_DOWN:
								btnDown_flag = true;
								TouchThread to = new TouchThread("__L");
								to.start();
								break;
							case MotionEvent.ACTION_UP:
								btnDown_flag = false;
								break;
							case MotionEvent.ACTION_CANCEL:
								btnDown_flag = false;
								break;
							default : 
								btnDown_flag = false;
								break;
							}
						}
						return false;

					}
				});
				btn_right.setOnTouchListener(new View.OnTouchListener() {
					@Override
					public boolean onTouch(View v, MotionEvent event) {

						if (master_flag) {
							switch (event.getAction()) {
							case MotionEvent.ACTION_DOWN:
								btnDown_flag = true;
								TouchThread to = new TouchThread("__R");
								to.start();
								break;
							case MotionEvent.ACTION_UP:
								btnDown_flag = false;
								break;
							case MotionEvent.ACTION_CANCEL:
								btnDown_flag = false;
								break;
							default : 
								btnDown_flag = false;
								break;
							
							}
						}
						return false;

					}
				});
				mhandler = new Handler() {
					@Override
					public void handleMessage(Message msg) {
						super.handleMessage(msg);
						bitmap = (Bitmap) msg.obj;
						view_pi.setImageBitmap(bitmap);
						view_pi.invalidate();
					}
				};
				initalhandler = new Handler() {
					@Override
					public void handleMessage(Message msg) {
						super.handleMessage(msg);
						view_pi.setImageBitmap(null);
					}
				};
				break;

			case 1:
				v = mInflater.inflate(R.layout.inflate_chat, null);
				btn_send = (Button) v.findViewById(R.id.btn_send);
				ed_msg = (EditText) v.findViewById(R.id.ed_msg);
				txt_chat = (TextView) v.findViewById(R.id.txt_chat);
				scrollview = (ScrollView) v.findViewById(R.id.scroll_view);

				// calendar = Calendar.getInstance();
				btn_send.setOnClickListener(new View.OnClickListener() {
					@Override
					public void onClick(View v) {

						String chatmsg = ed_msg.getText().toString();
						if (chatmsg.equals("/clear")) {
							txt_chat.setText("");
							ed_msg.setText("");
						} else if (!chatmsg.equals("")) {
							sendChatMsg(intent_id + " : " + chatmsg);
							ed_msg.setText("");
						}
					}
				});

				txthandler = new Handler() {
					public void handleMessage(Message msg) {
						super.handleMessage(msg);
						Log.d("check", "chat message : " + msg.obj.toString());
						// int hr = calendar.get(Calendar.HOUR_OF_DAY);
						// int mt = calendar.get(Calendar.MINUTE);
						// String hour = hr > 9 ? Integer.toString(hr) : "0"
						// + Integer.toString(hr);
						// txt_chat.append("[" + hour + ":" + mt + "]");
						txt_chat.append((CharSequence) msg.obj + "\n");
						scrollview.fullScroll(ScrollView.FOCUS_DOWN);
					}
				};

				break;

			}
			((ViewPager) pager).addView(v, null);
			return v;
		}

		public void destroyItem(View pager, int position, Object view) {
			((ViewPager) pager).removeView((View) view);
		}

		public boolean isViewFromObject(View v, Object obj) {
			return v == obj;
		}

	}

	@Override
	public void onClick(View v) {
		switch (v.getId()) {
		case R.id.btn_one:
			setCurrentInflateItem(0);
			break;
		case R.id.btn_two:
			setCurrentInflateItem(1);
			break;
		}
	}

	private static byte[] read_data(InputStream in, int len) throws Exception {
		java.io.ByteArrayOutputStream bout = new java.io.ByteArrayOutputStream();
		int bcount = 0;
		byte[] buf = new byte[2048];
		while (bcount < len) {
			int n = in.read(buf, 0, len - bcount < 2048 ? len - bcount : 2048);
			if (n == -1)
				break;
			// System.out.println(n);
			bcount += n;
			bout.write(buf, 0, n);
		}
		bout.flush();
		// return bout.toString();
		return bout.toByteArray();
	}
}
