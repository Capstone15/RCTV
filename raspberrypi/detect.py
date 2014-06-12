import subprocess
import os
import picamera
import re
import urllib
import time



while 1:
	try:
		urllib.urlopen('http://myexternalip.com/raw').read()

		p = os.popen("ps -Af").read()
		list = p.split('\n')
		listsize = len(list)


		result = ""

		flag = 0

		for i in range(0, listsize):
			if 'python /home/pi/Desktop/rctv.py' in list[i]:
				print 'rctv running'
				flag = 1
		if flag == 0:
			print "not running"
			subprocess.call('python /home/pi/Desktop/rctv.py 17247 &', shell=True)


	except:
		print "int not con"

		p = os.popen("ps -Af").read()
		list = p.split('\n')
		listsize = len(list)


		result = ""
		pid = ""

		for i in range(0, listsize):
			if 'python /home/pi/Desktop/rctv.py' in list[i]:
				result = list[i]

		pid = re.findall('\d{3,4}', result)
		if(pid != []):
			pid = pid[0]
			killcommand = "sudo kill %s" % (pid)
			print "kill rctv"
			subprocess.call(killcommand, shell=True)


		print 'ifdown'
		subprocess.call('sudo ifdown wlan0', shell=True)
		print 'ifup'
		subprocess.call('sudo ifup wlan0', shell=True)

		time.sleep(5)
		print 'dhc client'
		subprocess.call('sudo dhclient wlan0', shell=True)
		

		while 1:
			try:
				urllib.urlopen('http://myexternalip.com/raw')
				break
			except:
				subprocess.call('sudo dhclient wlan0', shell=True)


		time.sleep(5)
	
		print "run !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"
		subprocess.call('python /home/pi/Desktop/rctv.py 17247&', shell=True)



	time.sleep(10)








