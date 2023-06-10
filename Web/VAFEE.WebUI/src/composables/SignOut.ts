import { Auth, signOut } from "firebase/auth";
import { useUserStore } from "@/stores/user";


export const useSignOut = (auth: Auth) => {
    signOut(auth).then(() => {
        // Sign-out successful.
        const userStore = useUserStore();
        userStore.$reset();
    }).catch((error) => {
        // An error happened.
        console.log(error);
    });
}