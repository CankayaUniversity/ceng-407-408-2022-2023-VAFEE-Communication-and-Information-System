import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/foundation.dart';

Future initFirebase() async {
  if (kIsWeb) {
    await Firebase.initializeApp(
        options: FirebaseOptions(
            apiKey: "AIzaSyBe9JrP1qOH2XKeiP62YyJDFrEC0qG9fMU",
            authDomain: "vafee-91686.firebaseapp.com",
            projectId: "vafee-91686",
            storageBucket: "vafee-91686.appspot.com",
            messagingSenderId: "151275153008",
            appId: "1:151275153008:web:c8aa4a3e99eab53be8f6b5"));
  } else {
    await Firebase.initializeApp();
  }
}
