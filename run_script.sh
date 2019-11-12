#!/bin/bash

echo "Creating PostgreDB in local k8s cluster"

kubectl apply -f deployments/postgres.yaml

sleep 2;

echo "Monitoring PostgreDB deployment"

pod=$(kubectl -n default get pods -o name | grep postgres)

podStatus=$(kubectl -n default wait --for condition=Ready $pod --timeout=5m)
    if [[ "$podStatus" != *"condition met" ]]; then
        echo "Error: PostgreDB pod not ready"
        exit 1
    fi

kubectl -n default get $pod

echo "Building docker image for main application"

docker build -t university/linuxcontainer:latest .

echo "Deploying application in local k8s cluster"

kubectl apply -f deployments/app.yaml

sleep 2;

pod=$(kubectl -n default get pods -o name | grep linux-containers)

podStatus=$(kubectl -n default wait --for condition=Ready $pod --timeout=2m)
    if [[ "$podStatus" != *"condition met" ]]; then
        echo "Error: Linux containers app pod not ready"
        exit 1
    fi

echo "Ready to use.."
