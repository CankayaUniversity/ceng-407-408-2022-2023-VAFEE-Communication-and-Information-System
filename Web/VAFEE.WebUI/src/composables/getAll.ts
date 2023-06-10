const querySnapshotAnnouncement = await getDocs(collection(firestore, "announcements"));
    querySnapshotAnnouncement.forEach((doc) => {
        // doc.data() is never undefined for query doc snapshots
        console.log(doc.id, " => ", doc.data());
        announcements.value.push(doc.data())
    });