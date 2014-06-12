import io
import socket
import struct
import time
import picamera
import os
import sys
import thread

import pymssql  # DB
import urllib   # URL
import re       # regulation


#####################################################################################
#
#
#   variable declaration
#
serialNum = "A0001"

IP = ""
IMG_PORT = int(sys.argv[1])
CHAT_PORT = IMG_PORT + 1
EMPTY = -1

current_client = 0
img_list = range(4)
chat_list = range(4)
leng = 0


for i in range(0,4):
	img_list[i] = EMPTY

for i in range(0,4):
	chat_list[i] = EMPTY



#####################################################################################





#####################################################################################
#
#
#       get external ip and send to DB server
#
#


def getExternalIP():
	ext_ip = urllib.urlopen('http://myexternalip.com/raw').read().split()[0]
	print ext_ip


	conn = pymssql.connect(host='203.246.112.87:49304', user='sa', password='22179215', database='rctv')
	cursor = conn.cursor()
	#cursor.execute("INSERT INTO raspberry VALUES('C0001', '123.123.123.123', 2347)")
	cursor.execute("UPDATE raspberrypi SET RaspIP = '%s', imgPORT = '%s', chatPort = '%s' WHERE RaspNumber = '%s'" % (ext_ip, IMG_PORT, CHAT_PORT, serialNum) )
	conn.commit()
	conn.close()

#####################################################################################




#####################################################################################
#
#
#       send img function to client
#
#

def imageSender(junk):
	global current_client
	global img_list
	global EMPTY
	global leng
	with picamera.PiCamera() as camera:
		camera.resolution = (320, 240)

	        flag = 0;

        	stream = io.BytesIO()

	        # Use the video-port for captures...
		for foo in camera.capture_continuous(stream, 'jpeg', use_video_port=True):
			if current_client > 0:
				for i in range(0,4):
					if img_list[i]!=EMPTY:
						leng = stream.tell()
						
						connection = img_list[i].makefile('wb')
						connection.write(struct.pack('<I', leng))
						#print "i : ", i, " leng : ", leng							
						connection.flush()
				stream.seek(0)				
				for i in range(0,4):
					if img_list[i]!=EMPTY:
						connection = img_list[i].makefile('wb')
						connection.write(stream.read())
						stream.seek(0)
			stream.seek(0)	
			stream.truncate()


########################################################################






#####################################################################################
#
#
#       client img sock control
#
#
	
# if client connect to me, server add client list
def pushClient(c_socket):
	global current_client
	global img_list
	global EMPTY
    
	for i in range(0,4):
		if img_list[i] == EMPTY:
			img_list[i] = c_socket
            #current_client = current_client+1
			break
	
#print current_client

#if client disconnects from server, server removes from client list
def popClient(c_socket):
	global current_client
	global img_list
	global EMPTY
    
	for i in range(0,4):
		if img_list[i] == c_socket:
			img_list[i] = EMPTY
    #current_client = current_client -1
    #print current_client

#if client sends a disconnect message to server, server disconnects from client
def disconnReceiver(c_socket, c_addr):
	while 1:
		msg = c_socket.recv(128)
		print msg
        
        
		if msg =="quit":
			popClient(c_socket)
			break
		else
			print msg
			if current_client > 0:
				for i in range(0,4):
					if img_list[i]!=EMPTY:
						imf_list[i].sendall(msg)


#####################################################################################
#
#
#       client chat sock control

#
#



# if client connect to me, server add client list
def pushClient2(c_socket):
	global current_client
	global chat_list
	global EMPTY
    
	for i in range(0,4):
		if chat_list[i] == EMPTY:
			chat_list[i] = c_socket
			current_client = current_client+1
			break
	
	print current_client

#if client disconnects from server, server removes from client list
def popClient2(c_socket):
	global current_client
	global chat_list
	global EMPTY
    
	for i in range(0,4):
		if chat_list[i] == c_socket:
			chat_list[i] = EMPTY
			current_client = current_client -1
	print current_client

#if client sends a disconnect message to server, server disconnects from client
def disconnReceiver2(c_socket, c_addr):
	global current_client
	global chat_list
	global EMPTY
        
        
	while 1:
		msg = c_socket.recv(128)
	        print msg
        
        	if current_client > 0:
	            for i in range(0,4):
	                if img_list[i]!=EMPTY:
	                    chat_list.send(msg)

		if msg == NULL:
			popClient(c_socket)
			break



#####################################################################################
#
#
#       main function
#
#

if __name__ == "__main__":

	getExternalIP()

	
	img_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	img_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
    
   	#chat_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
	#chat_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)


	while 1:
        	try:
	            img_socket.bind((IP, IMG_PORT))
	            img_socket.listen(4)
	            print "img port:", PORT
	            break
	        except:
	            IMG_PORT = IMG_PORT + 1
	        
        
	#while 1:
	#	try:
	#		chat_socket.bind((IP, CHAT_PORT))
	#		chat_socket.listen(4)
	#		print "chat port:", CHAT_PORT
	#		break
	#	except:
	#		CHAT_PORT = CHAT_PORT + 1




	thread.start_new_thread(imageSender, (0,))


	while 1:
		conn, addr = img_socket.accept()
        	print addr
	 #       conn2, addr2 = chat_socket.accept()
	 #       print addr2
            
		if(current_client < 4):
			pushClient(conn)
	#	        pushClient(conn2)
			
			thread.start_new_thread(disconnReceiver, (conn, addr))
	#	        thread.start_new_thread(disconnReceiver, (conn2, addr2))
		else:
			print "Full"

	img_socket.close()
	#chat_socket.close()