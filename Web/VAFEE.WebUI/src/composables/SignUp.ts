import { auth } from "@/firebase/config"
import { createUserWithEmailAndPassword, Auth } from "firebase/auth"


export const useSignUp = (auth: Auth, email: string, password: string) => {
    createUserWithEmailAndPassword(auth, email, password)
        .then((userCredential) => {
            // Signed in 
            const user = userCredential.user;
            // ...
            
        })
        .catch((error) => {
            const errorCode = error.code;
            const errorMessage = error.message;
            // ..
        });
}