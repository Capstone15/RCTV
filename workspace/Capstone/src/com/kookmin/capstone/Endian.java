package com.kookmin.capstone;

public class Endian {

	public static byte[] getLittleEndian(int v) {
		byte[] buf = new byte[4];
		buf[3] = (byte) ((v >>> 24) & 0xFF);
		buf[2] = (byte) ((v >>> 16) & 0xFF);
		buf[1] = (byte) ((v >>> 8) & 0xFF);
		buf[0] = (byte) ((v >>> 0) & 0xFF);
		return buf;
	}

	public static int getBigEndian(byte[] v) throws Exception {
		int[] arr = new int[4];
		for (int i = 0; i < 4; i++)
			arr[i] = (int) (v[3 - i] & 0xFF);
		return ((arr[0] << 24) + (arr[1] << 16) + (arr[2] << 8) + (arr[3] << 0));
	}
}
