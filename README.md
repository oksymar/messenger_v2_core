# messenger_v2_core

Install MOSCA:
sudo npm install mosca pino -g

Run MOSCA:
mosca -v --only-http | pino

Change ip addr for MOSCA in:
/wwwroot/js/chatPage.js -> MQTT_BROKER_ADDR
/Controllers/ChatController.cs -> MQTT_BROKER_ADDR

Database don't work for now.
