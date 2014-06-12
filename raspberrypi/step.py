import time
import RPi.GPIO as GPIO


def run(re,direction,wpin,wt):
    
    GPIO.setmode(GPIO.BOARD)
    GPIO.setwarnings(False)
    pins_A = [11,12,13,15] #board
    pins_B = [7,16,18,22] #board
    WaitTime=wt
    StepCount=4
    
    Seq1=[]
    Seq1=range(0,StepCount)
    Seq1[0]=[1,0,0,0]
    Seq1[1]=[0,1,0,0]
    Seq1[2]=[0,0,1,0]
    Seq1[3]=[0,0,0,1]
    
    Seq2=[]
    Seq2=range(0,StepCount)
    Seq2[0]=[0,0,0,1]
    Seq2[1]=[0,0,1,0]
    Seq2[2]=[0,1,0,0]
    Seq2[3]=[1,0,0,0]

    Seq=[]
    pins=[]
    if direction == "front":
        Seq = Seq1
    elif direction == "back":
        Seq = Seq2
    if wpin == 'A':
        pins = pins_A
    elif wpin == 'B':
        pins = pins_B
        
    #setup pin
    print "Setup pins %s" %(wpin)
    for pin in pins:
        GPIO.setup(pin,GPIO.OUT)
        GPIO.output(pin,False)
    StepCounter=0
    i=0
    #start main loop
    while i<re:
        for pin in range(0,4):
            xpin = pins[pin]
            if Seq[StepCounter][pin]!=0:
                GPIO.output(xpin,True)
                print " Step %d Enable %d" %(StepCounter,xpin)
            else:
                GPIO.output(xpin, False)
        
        StepCounter = StepCounter+1
        if (StepCounter==StepCount):
            StepCounter=0
        if (StepCounter<0):
            StepCounter = Stepcount
        time.sleep(WaitTime)
        i+=1
try:
    run(300,"front",'A',0.0025)
    run(300,"back",'A',0.0025)
    #run(4,"front",'B')
    #run(4,"back",'B')
except KeyboardInterrupt:
    GPIO.cleanup()

