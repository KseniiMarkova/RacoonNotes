export const userSchema = `#graphql
  type GetUserByIdResponceMessage {
    UserId: ID!
    UserName: String
    Email: String
    IsBanned: Boolean
  }

  input CreateUserRequestInput {
    email: String!
    name: String!
    password: String!
    registrationCountry: String!
  }
  
  type CreateUserResponse {
    UserId: ID!
  }

  type Query {
    getUserById(userId: ID!): GetUserByIdResponceMessage
  }

  type Mutation {
    createUser(input: CreateUserRequestInput!): CreateUserResponse!
  }
`;
