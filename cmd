#!/bin/bash

SERVICE_NAME=trader-studio-web
IMAGE_NAME=trader-studio-web
TAG=latest
SERVICE_PORT=9998
CONTAINER_PORT=8080

case $1 in
    build)
        docker build -t $IMAGE_NAME .
        ;;
    pull)
        docker pull msat7201/$IMAGE_NAME:$TAG
        ;;
    start)
        docker run -d -it -p $SERVICE_PORT:$CONTAINER_PORT --restart=always --name $SERVICE_NAME msat7201/$IMAGE_NAME:$TAG
        ;;
    stop)
        docker stop $SERVICE_NAME && docker rm $SERVICE_NAME || true  
        ;;
    restart)
        ./cmd pull
        ./cmd stop
        ./cmd start
        ;;
    *)
        echo "Usage: $0 {start|stop|restart|build}"
        exit 1
        ;;
esac