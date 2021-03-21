# RabbitMqExperiment
Simple project containing an API that publish messages to RabbitMq, and a worker that consume the messages. 

## RabbitMq docker command
docker run -d --hostname rabbitserver --name rabbitmq-server -p 15672:15672 -p 5672:5672 rabbitmq:3-management
