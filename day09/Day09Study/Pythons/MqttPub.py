## 파이썬 MQTT Publish
# paho-mqtt 라이브러리 설치
# pip install pho-mqtt
import paho.mqtt.client as mqtt
import json
import datetime as dt
import uuid
from collections import OrderedDict
import random
import time

PUB_ID = 'IOT73' # 아이피 마지막 주소
BROKER = '210.119.12.73'
PORT = 1883
TOPIC = 'smarthome/73/topic' # publish/subscribe에서 사용할 토픽(핵심)
COLORS = ['RED', 'ORANGE', 'YELLOW', 'GREEN', 'BLUE', 'NAVY', 'PURPLE']
COUNT = 0

# [Fake] 센서 설정
SENSOR1 = "온도센서셋팅"; PIN1 = 5
SENSOR2 = "포토센서셋팅"; PIN2 = 7
SENSOR3 = "워터드롭센서셋팅"; PIN3 = 9
SENSOR4 = "인체감지센서셋팅"; PIN4 = 11


# 연결 콜백
def on_connect(client, userdata, flags, reason_code, properties=None):
    print(f'Connected with reason code : {reason_code}')

# 퍼블리스 완료 후 콜백
def on_publish(client, userdata, mid):
    print(f'Message Publish mid : {mid}')

try:
    client = mqtt.Client(client_id=PUB_ID, protocol=mqtt.MQTTv5)
    client.on_connect = on_connect
    client.on_publish = on_publish

    client.connect(BROKER, PORT)
    client.loop_start()

    while True:
        # 퍼블리시
        currtime = dt.datetime.now()
        selected = random.choice(COLORS)
        temp = random.uniform(20.0, 25.9) # [Fake] 온도, 실제로는 센서에서 값을 받아옴
        humid = random.uniform(40.0, 65.9) # [Fake] 습도, 실제로는 센서에서 값을 받아옴
        rain = random.randint(0, 1) # [Fake] 비,  실제로는 센서에서 값을 받아옴, 0은 맑음. 1은 비
        detect = random.randint(0, 1) # [Fake] 인체센서, 실제로는 센서에서 값을 받아옴
        photo = random.randint(50, 255) # [Fake] 포토센서, 255쪽이 어두움 센싱

        COUNT += 1
        
        ## 센싱데이터를 json형태로 변경
        ## OrderedDict로 먼저 구성. 순서가 있는 딕셔너리타입 객체
        raw_data = OrderedDict()
        raw_data['PUB_ID'] = PUB_ID
        raw_data['COUNT'] = COUNT
        raw_data['SENSING_DT'] = currtime.strftime(f'%Y-%m-%d %H:%M:%S') # 'yyyy-MM-dd HH:mm:ss'
        raw_data['TEMP'] = f'{temp:0.1f}' # 소수점 1자리만 
        raw_data['HUMID'] = f'{humid:0.1f}'
        raw_data['LIGHT'] = photo
        raw_data['HUMAN'] = detect
        # Python 딕셔너리 형태로 저장돼 있음. json이랑 거의 똑같음

        ## OrderedDict => json 타입으로 변경
        pub_data = json.dumps(raw_data, ensure_ascii=False, indent='\t')

        ## payloade에 json 데이터를 할당
        client.publish(TOPIC, payload=pub_data, qos=1)
        time.sleep(1)

except Exception as ex:
    print(f'Error raised : {ex}')

except KeyboardInterrupt:
    print('MQTT 전송중단')
    client.loop_stop()
    client.disconnect()