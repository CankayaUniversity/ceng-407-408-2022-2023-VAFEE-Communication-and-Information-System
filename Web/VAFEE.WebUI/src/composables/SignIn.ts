import { auth, firestore } from "@/firebase/config"
import { collection, query, where } from "firebase/firestore";
import { signInWithEmailAndPassword, Auth } from "firebase/auth"

import { useUserStore } from "@/stores/user";
import { getUserCourses } from "./getUserCourses";

export const useSignIn = (auth: Auth, email: string, password: string) => {


    const usersRef = collection(firestore, "users");

    console.log(usersRef);
    // Create a query against the collection.
    const q = query(usersRef, where("email", "==", email));

    console.log(q);

    signInWithEmailAndPassword(auth, email, password)
        .then((userCredential) => {
            // Signed in 
            const user = userCredential.user;

            // set pinia store user state
            const userStore = useUserStore();
            userStore.username = user?.displayName;
            userStore.email = user?.email;
            userStore.image = user?.photoURL;
            userStore.name = user?.displayName;
            userStore.id = user?.uid;
            userStore.courses = getUserCourses(user?.uid!)

            console.log(user);


        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
        });




}