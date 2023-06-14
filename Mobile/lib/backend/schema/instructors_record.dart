import 'dart:async';

import '/backend/schema/util/firestore_util.dart';
import '/backend/schema/util/schema_util.dart';

import 'index.dart';
import '/flutter_flow/flutter_flow_util.dart';

class InstructorsRecord extends FirestoreRecord {
  InstructorsRecord._(
    DocumentReference reference,
    Map<String, dynamic> data,
  ) : super(reference, data) {
    _initializeFields();
  }

  // "instructor_name" field.
  String? _instructorName;
  String get instructorName => _instructorName ?? '';
  bool hasInstructorName() => _instructorName != null;

  // "instructor_surname" field.
  String? _instructorSurname;
  String get instructorSurname => _instructorSurname ?? '';
  bool hasInstructorSurname() => _instructorSurname != null;

  // "department" field.
  String? _department;
  String get department => _department ?? '';
  bool hasDepartment() => _department != null;

  // "courses_taught" field.
  List<String>? _coursesTaught;
  List<String> get coursesTaught => _coursesTaught ?? const [];
  bool hasCoursesTaught() => _coursesTaught != null;

  // "uid" field.
  String? _uid;
  String get uid => _uid ?? '';
  bool hasUid() => _uid != null;

  void _initializeFields() {
    _instructorName = snapshotData['instructor_name'] as String?;
    _instructorSurname = snapshotData['instructor_surname'] as String?;
    _department = snapshotData['department'] as String?;
    _coursesTaught = getDataList(snapshotData['courses_taught']);
    _uid = snapshotData['uid'] as String?;
  }

  static CollectionReference get collection =>
      FirebaseFirestore.instance.collection('instructors');

  static Stream<InstructorsRecord> getDocument(DocumentReference ref) =>
      ref.snapshots().map((s) => InstructorsRecord.fromSnapshot(s));

  static Future<InstructorsRecord> getDocumentOnce(DocumentReference ref) =>
      ref.get().then((s) => InstructorsRecord.fromSnapshot(s));

  static InstructorsRecord fromSnapshot(DocumentSnapshot snapshot) =>
      InstructorsRecord._(
        snapshot.reference,
        mapFromFirestore(snapshot.data() as Map<String, dynamic>),
      );

  static InstructorsRecord getDocumentFromData(
    Map<String, dynamic> data,
    DocumentReference reference,
  ) =>
      InstructorsRecord._(reference, mapFromFirestore(data));

  @override
  String toString() =>
      'InstructorsRecord(reference: ${reference.path}, data: $snapshotData)';

  @override
  int get hashCode => reference.path.hashCode;

  @override
  bool operator ==(other) =>
      other is InstructorsRecord &&
      reference.path.hashCode == other.reference.path.hashCode;
}

Map<String, dynamic> createInstructorsRecordData({
  String? instructorName,
  String? instructorSurname,
  String? department,
  String? uid,
}) {
  final firestoreData = mapToFirestore(
    <String, dynamic>{
      'instructor_name': instructorName,
      'instructor_surname': instructorSurname,
      'department': department,
      'uid': uid,
    }.withoutNulls,
  );

  return firestoreData;
}
