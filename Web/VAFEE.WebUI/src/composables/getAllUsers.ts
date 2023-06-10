import { firestore } from "@/firebase/config";
import { collection, getDocs } from "firebase/firestore";



export const getAllUsers = async () => {
    const querySnapshot = await getDocs(collection(firestore, "users"));
    querySnapshot.forEach((doc) => {
        
        console.log(doc.data());
        
    });
}