
import { firestore, auth } from "@/firebase/config";
import { collection, doc } from "firebase/firestore";


export const getUser = async () => {

    const usersRef = collection(firestore, 'users');
    const user = auth.currentUser;

}