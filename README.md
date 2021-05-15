# Prometheus Demo

## About: <br/>
This is an ASP.Net Core application for understanding the basic usage of prometheus. It makes http call to Github API and retrieves profile of the desired user. You need to provide username in the url of the application. In this application I'm monitoring the count of http calls and latency of each call.<br/><br/>


## How to run?<br/>
Clone this project in Visual Studio and run it. The application runs on **localhost:5001**. So to get the profile of a user having username ***xyz***, open ***localhost:5001/users/xyz*** in your browser.<br/><br/>


## Metrics:
Once the application up and running, you can see the metrics of the application at ***localhost:5001/metrics***. You'll have to import ***prometheus-net.AspNetCore*** nuget.
You'll see a bunch of labels and their corresponding values at /metrics url.<br/>
- Among them you'll find **get_calls_counter** label and it's value next to it. It shows how many times call to Github API was made. This metric is of type **Counter**.<br/>
- There is one more label called **get_calls_latency**. It's of type **Histogram**. Depending on the latency the calls will be put in appropriate buckets: bucket of <1s, bucket of <2s and so on.<br/><br/>


## Prometheus Dashboard:
The data you see at /metrics url is a bit difficult to read and maybe a bit confusing too. That's where prometheus dashboard comes handy. Using this dashboard, you'll able to plot graphs of the metrics. Visuals are always better to understand.<br/>
- For that you have to install prometheus on your machine. You can get it from https://prometheus.io/download/. You'll find a file **prometheus.yml** in the folder. Modify that YML file add one more target: this demo application. You can use https://prometheus.io/docs/prometheus/latest/configuration/configuration/ for help. Once it's done, run **prometheus.exe**. <br/>
- By default, prometheus runs on 9090 port. Open it in your browser. You'll find a textbox for running prometheus queries. In the topmost ribbon, go to Status -> Target. You should see localost:5001/metrics in the targets.
- Now go to homepage, select Graph and type "get_calls_counter" in the textbox and execute. You'll see the graph of count of http requests against time. Similarly you can run queries for other labels as well. Visit https://prometheus.io/docs/prometheus/latest/querying/basics/ for more.
