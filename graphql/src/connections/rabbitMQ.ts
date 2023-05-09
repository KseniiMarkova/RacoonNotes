import amqp, { Channel, Connection } from 'amqplib';

const RABBITMQ_CONNECTION_STRING = 'amqp://racoon:gfyutz@localhost:5672';

let connection: Connection, channel: Channel;

async function connectRabbitMQ(exchangeName: string, queueName: string) {
    connection = await amqp.connect(RABBITMQ_CONNECTION_STRING);
    channel = await connection.createChannel();

    connection.on('error', (err) => {
        console.error('Connection to RabbitMQ lost:', err);
        closeRabbitMQ(connection);
    });

    await channel.assertExchange(exchangeName, 'direct', { durable: true });
    const q = await channel.assertQueue(queueName);
    await channel.bindQueue(q.queue, exchangeName, '');

    return { connection, channel };
}

async function closeRabbitMQ(connection) {
    await connection.close();
}

export { connectRabbitMQ, closeRabbitMQ };