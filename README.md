# EventHubsWithKafkaSDK

### Introduction

Azure Event Hubs have historically been very similar to Kafka. Today we're going to explore at a basic level some of those similarities. 

It is a common scenario in the cloud to swap out for similar technologies or infrastructure. But often this comes with significant development overhead. Since Event Hubs and Kafka are highly similar, we'll look at the minimum amount of effort it will take to move between them. In this scenario, we're going to assume a codebase that is built around Kafka and a Kafka-native SDK. We'll then point the configuration of this code to the Event Hub endpoint and look what needs to change in order to make this work.

### Migration Process
// TODO: Add steps

### Conclusion

It is really refreshing being able to target an entirely different service with an SDK that wasn't built for it. However, we need to remember that we only have compared the most basic feature of each technology, delivering and reading messages off of the queues. There are many more aspects that we haven't looked into. However, since we have unlocked the hardest part of the migration, it will be easy to test the rest.
