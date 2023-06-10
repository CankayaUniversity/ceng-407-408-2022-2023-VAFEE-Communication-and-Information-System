
import { firestore } from "@/firebase/config";
import { collection, query, where, getDocs, doc } from "firebase/firestore";


export const getUserCourses = async (userId: string) => {


    const docRef = doc(firestore, "classes", "XUqbYwhWjiIwJdcASMkO");
    const querySnapshot = await getDocs(collection(firestore, "classes"));
    const q = query(collection(firestore, "classes"), where("instructors", "array-contains", "Gül Tokdemir"));

    querySnapshot.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        doc.data().users.forEach(user => {
            if (user.id === "example") {
                console.log("sa");
            }
        });
    });



    // console.log(docSnap.data().users.forEach(user => {
    //     if (user.id === "HLL6I0CnpJf2paZbde54dxpEplV2") {
    //         console.log(user);
    //     }
    // }));

    // var docRef = collection(firestore, "classes");
    // console.log(getDoc(docRef));
    // const q = query(docRef, where("code", "==", "111"));



};