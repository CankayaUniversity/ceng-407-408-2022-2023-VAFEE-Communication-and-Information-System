import 'dart:async';

import '/backend/schema/util/firestore_util.dart';
import '/backend/schema/util/schema_util.dart';

import 'index.dart';
import '/flutter_flow/flutter_flow_util.dart';

class ClassesRecord extends FirestoreRecord {
  ClassesRecord._(
    DocumentReference reference,
    Map<String, dynamic> data,
  ) : super(reference, data) {
    _initializeFields();
  }

  // "code" field.
  String? _code;
  String get code => _code ?? '';
  bool hasCode() => _code != null;

  // "description" field.
  String? _description;
  String get description => _description ?? '';
  bool hasDescription() => _description != null;

  // "instructors" field.
  List<String>? _instructors;
  List<String> get instructors => _instructors ?? const [];
  bool hasInstructors() => _instructors != null;

  // "users" field.
  List<DocumentReference>? _users;
  List<DocumentReference> get users => _users ?? const [];
  bool hasUsers() => _users != null;

  // "department" field.
  String? _department;
  String get department => _department ?? '';
  bool hasDepartment() => _department != null;

  // "name" field.
  String? _name;
  String get name => _name ?? '';
  bool hasName() => _name != null;

  // "term" field.
  String? _term;
  String get term => _term ?? '';
  bool hasTerm() => _term != null;

  // "monday" field.
  String? _monday;
  String get monday => _monday ?? '';
  bool hasMonday() => _monday != null;

  // "tuesday" field.
  String? _tuesday;
  String get tuesday => _tuesday ?? '';
  bool hasTuesday() => _tuesday != null;

  // "wednesday" field.
  String? _wednesday;
  String get wednesday => _wednesday ?? '';
  bool hasWednesday() => _wednesday != null;

  // "thursday" field.
  String? _thursday;
  String get thursday => _thursday ?? '';
  bool hasThursday() => _thursday != null;

  // "friday" field.
  String? _friday;
  String get friday => _friday ?? '';
  bool hasFriday() => _friday != null;

  // "userDENEME" field.
  List<String>? _userDENEME;
  List<String> get userDENEME => _userDENEME ?? const [];
  bool hasUserDENEME() => _userDENEME != null;

  void _initializeFields() {
    _code = snapshotData['code'] as String?;
    _description = snapshotData['description'] as String?;
    _instructors = getDataList(snapshotData['instructors']);
    _users = getDataList(snapshotData['users']);
    _department = snapshotData['department'] as String?;
    _name = snapshotData['name'] as String?;
    _term = snapshotData['term'] as String?;
    _monday = snapshotData['monday'] as String?;
    _tuesday = snapshotData['tuesday'] as String?;
    _wednesday = snapshotData['wednesday'] as String?;
    _thursday = snapshotData['thursday'] as String?;
    _friday = snapshotData['friday'] as String?;
    _userDENEME = getDataList(snapshotData['userDENEME']);
  }

  static CollectionReference get collection =>
      FirebaseFirestore.instance.collection('classes');

  static Stream<ClassesRecord> getDocument(DocumentReference ref) =>
      ref.snapshots().map((s) => ClassesRecord.fromSnapshot(s));

  static Future<ClassesRecord> getDocumentOnce(DocumentReference ref) =>
      ref.get().then((s) => ClassesRecord.fromSnapshot(s));

  static ClassesRecord fromSnapshot(DocumentSnapshot snapshot) =>
      ClassesRecord._(
        snapshot.reference,
        mapFromFirestore(snapshot.data() as Map<String, dynamic>),
      );

  static ClassesRecord getDocumentFromData(
    Map<String, dynamic> data,
    DocumentReference reference,
  ) =>
      ClassesRecord._(reference, mapFromFirestore(data));

  @override
  String toString() =>
      'ClassesRecord(reference: ${reference.path}, data: $snapshotData)';

  @override
  int get hashCode => reference.path.hashCode;

  @override
  bool operator ==(other) =>
      other is ClassesRecord &&
      reference.path.hashCode == other.reference.path.hashCode;
}

Map<String, dynamic> createClassesRecordData({
  String? code,
  String? description,
  String? department,
  String? name,
  String? term,
  String? monday,
  String? tuesday,
  String? wednesday,
  String? thursday,
  String? friday,
}) {
  final firestoreData = mapToFirestore(
    <String, dynamic>{
      'code': code,
      'description': description,
      'department': department,
      'name': name,
      'term': term,
      'monday': monday,
      'tuesday': tuesday,
      'wednesday': wednesday,
      'thursday': thursday,
      'friday': friday,
    }.withoutNulls,
  );

  return firestoreData;
}
