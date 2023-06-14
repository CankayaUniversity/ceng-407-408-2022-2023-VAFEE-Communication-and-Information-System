import 'dart:async';

import '/backend/schema/util/firestore_util.dart';
import '/backend/schema/util/schema_util.dart';

import 'index.dart';
import '/flutter_flow/flutter_flow_util.dart';

class ConferencesRecord extends FirestoreRecord {
  ConferencesRecord._(
    DocumentReference reference,
    Map<String, dynamic> data,
  ) : super(reference, data) {
    _initializeFields();
  }

  // "conf_uid" field.
  String? _confUid;
  String get confUid => _confUid ?? '';
  bool hasConfUid() => _confUid != null;

  // "conf_title" field.
  String? _confTitle;
  String get confTitle => _confTitle ?? '';
  bool hasConfTitle() => _confTitle != null;

  // "conf_startdate" field.
  DateTime? _confStartdate;
  DateTime? get confStartdate => _confStartdate;
  bool hasConfStartdate() => _confStartdate != null;

  void _initializeFields() {
    _confUid = snapshotData['conf_uid'] as String?;
    _confTitle = snapshotData['conf_title'] as String?;
    _confStartdate = snapshotData['conf_startdate'] as DateTime?;
  }

  static CollectionReference get collection =>
      FirebaseFirestore.instance.collection('conferences');

  static Stream<ConferencesRecord> getDocument(DocumentReference ref) =>
      ref.snapshots().map((s) => ConferencesRecord.fromSnapshot(s));

  static Future<ConferencesRecord> getDocumentOnce(DocumentReference ref) =>
      ref.get().then((s) => ConferencesRecord.fromSnapshot(s));

  static ConferencesRecord fromSnapshot(DocumentSnapshot snapshot) =>
      ConferencesRecord._(
        snapshot.reference,
        mapFromFirestore(snapshot.data() as Map<String, dynamic>),
      );

  static ConferencesRecord getDocumentFromData(
    Map<String, dynamic> data,
    DocumentReference reference,
  ) =>
      ConferencesRecord._(reference, mapFromFirestore(data));

  @override
  String toString() =>
      'ConferencesRecord(reference: ${reference.path}, data: $snapshotData)';

  @override
  int get hashCode => reference.path.hashCode;

  @override
  bool operator ==(other) =>
      other is ConferencesRecord &&
      reference.path.hashCode == other.reference.path.hashCode;
}

Map<String, dynamic> createConferencesRecordData({
  String? confUid,
  String? confTitle,
  DateTime? confStartdate,
}) {
  final firestoreData = mapToFirestore(
    <String, dynamic>{
      'conf_uid': confUid,
      'conf_title': confTitle,
      'conf_startdate': confStartdate,
    }.withoutNulls,
  );

  return firestoreData;
}
