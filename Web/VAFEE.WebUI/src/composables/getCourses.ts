import { firestore } from "@/firebase/config";
import { Course } from "@/interfaces";
import { useUserStore } from "@/stores/user";
import { getDocs, collection } from "firebase/firestore";

export const getCourses = async () => {
    const querySnapshot = await getDocs(collection(firestore, "classes"));
    const userStore = useUserStore();
    querySnapshot.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        userStore.courses.push(doc.data() as Course);
        
    });


}