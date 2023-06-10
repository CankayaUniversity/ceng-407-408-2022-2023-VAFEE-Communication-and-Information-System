
import { initializeApp } from "firebase/app"
import { getFirestore } from "firebase/firestore"
import { getAuth } from "firebase/auth"

// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries


const firebaseConfig = {
    apiKey: "AIzaSyBe9JrP1qOH2XKeiP62YyJDFrEC0qG9fMU",
    authDomain: "vafee-91686.firebaseapp.com",
    projectId: "vafee-91686",
    storageBucket: "vafee-91686.appspot.com",
    messagingSenderId: "151275153008",
    appId: "1:151275153008:web:c8aa4a3e99eab53be8f6b5"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const firestore = getFirestore(app)
const auth = getAuth(app)

export { firestore, auth };