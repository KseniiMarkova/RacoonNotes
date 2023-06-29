import gql from 'graphql-tag'

const getUserSchema = gql`
query getUsers {
  users {
    email
    isBanned
    userId
    userName
  }
}
`;

export {getUserSchema}