import { useQuery } from '@vue/apollo-composable'
import { getUserSchema } from './schema'

function getUser() {
    return useQuery(getUserSchema);
}

export {getUser}