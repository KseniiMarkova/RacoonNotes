import { GraphQLError } from "graphql";
import { closeRabbitMQ, connectRabbitMQ } from "../connections/rabbitMQ.js";
import { IResolvers } from '@graphql-tools/utils';

const USER_EXCHANGE = 'UserExchange';
const USER_GOTTEN = 'UserGotten';
const USER_CREATED = 'UserCreated';
const USER_GET_QUEUE = 'UserGetQueue';
const USER_CREATE_QUEUE = 'UserCreateQueue';


export const userResolvers: IResolvers = {
    Query: {
        getUserById: async (parent, args, context, info) => {
            const { userId } = args;
            const { connection, channel } = await connectRabbitMQ(USER_EXCHANGE, USER_GET_QUEUE);

            const requestMessage = {
                UserId: userId,
            };
            console.log("Request:", requestMessage);

            const msg = Buffer.from(JSON.stringify(requestMessage));

            const replyQueue = await channel.assertQueue('', { exclusive: true });

            channel.publish(USER_EXCHANGE, USER_GOTTEN, msg, {
                replyTo: replyQueue.queue,
                correlationId: userId
            });

            const response = await new Promise((resolve, reject) => {
                channel.consume(replyQueue.queue, msg => {
                    if (msg.properties.correlationId === userId) {
                        const response = JSON.parse(msg.content.toString());
                        console.log("Response:", response);
                        channel.ack(msg);
                        if (response.ErrorMessage) {
                            reject(new GraphQLError(response.ErrorMessage));
                        } else {
                            resolve(response);
                        }
                    }
                }, { noAck: false  });
            });

            await closeRabbitMQ(connection);

            return response;
        },
    },
    Mutation: {
        createUser: async (parent, args, context, info) => {
            const { email, name, password, registrationCountry } = args.input;
            const { connection, channel } = await connectRabbitMQ(USER_EXCHANGE, USER_CREATE_QUEUE);

            const requestMessage = {
                Email: email,
                Name: name,
                Password: password,
                RegistrationCountry: registrationCountry,
            };
            console.log("Request:", requestMessage);

            const msg = Buffer.from(JSON.stringify(requestMessage));

            const replyQueue = await channel.assertQueue('', { exclusive: true });

            channel.publish(USER_EXCHANGE, USER_CREATED, msg, {
                replyTo: replyQueue.queue,
                correlationId: name,
            });

            const response = await new Promise((resolve, reject) => {
                channel.consume(replyQueue.queue, msg => {
                    if (msg.properties.correlationId === name) {
                        const response = JSON.parse(msg.content.toString());
                        console.log("Response:", response);
                        channel.ack(msg);
                        if (response.ErrorMessage) {
                            reject(new GraphQLError(response.ErrorMessage));
                        } else {
                            resolve(response);
                        }
                    }
                }, { noAck: false  });
            });

            await closeRabbitMQ(connection);

            return response;
        },
    }
};