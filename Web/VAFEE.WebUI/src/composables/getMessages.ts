import { firestore } from "@/firebase/config";
import { Announcement } from "@/interfaces";
import { useUserStore } from "@/stores/user";
import { getDocs, collection } from "firebase/firestore";

export const getAnnouncements = async () => {
    const querySnapshot = await getDocs(collection(firestore, "chats"));
    const userStore = useUserStore();
    querySnapshot.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        userStore.announcements.push(doc.data() as Announcement);
    });


}