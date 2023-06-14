import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'confid_model.dart';
export 'confid_model.dart';

class ConfidWidget extends StatefulWidget {
  const ConfidWidget({
    Key? key,
    required this.confid,
  }) : super(key: key);

  final String? confid;

  @override
  _ConfidWidgetState createState() => _ConfidWidgetState();
}

class _ConfidWidgetState extends State<ConfidWidget> {
  late ConfidModel _model;

  @override
  void setState(VoidCallback callback) {
    super.setState(callback);
    _model.onUpdate();
  }

  @override
  void initState() {
    super.initState();
    _model = createModel(context, () => ConfidModel());
  }

  @override
  void dispose() {
    _model.maybeDispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    context.watch<FFAppState>();

    return Text(
      widget.confid!,
      style: FlutterFlowTheme.of(context).bodyMedium,
    );
  }
}
