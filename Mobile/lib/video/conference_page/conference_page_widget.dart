import '/flutter_flow/flutter_flow_theme.dart';
import '/flutter_flow/flutter_flow_util.dart';
import '/custom_code/widgets/index.dart' as custom_widgets;
import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'conference_page_model.dart';
export 'conference_page_model.dart';

class ConferencePageWidget extends StatefulWidget {
  const ConferencePageWidget({
    Key? key,
    required this.conferenceID,
    String? username,
    required this.useruid,
  })  : this.username = username ?? 'edkkkk',
        super(key: key);

  final String? conferenceID;
  final String username;
  final String? useruid;

  @override
  _ConferencePageWidgetState createState() => _ConferencePageWidgetState();
}

class _ConferencePageWidgetState extends State<ConferencePageWidget> {
  late ConferencePageModel _model;

  final scaffoldKey = GlobalKey<ScaffoldState>();

  @override
  void initState() {
    super.initState();
    _model = createModel(context, () => ConferencePageModel());
  }

  @override
  void dispose() {
    _model.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    context.watch<FFAppState>();

    return GestureDetector(
      onTap: () => FocusScope.of(context).requestFocus(_model.unfocusNode),
      child: Scaffold(
        key: scaffoldKey,
        backgroundColor: FlutterFlowTheme.of(context).primaryBackground,
        body: Container(
          width: MediaQuery.of(context).size.width * 1.0,
          height: MediaQuery.of(context).size.height * 0.98,
          decoration: BoxDecoration(
            color: FlutterFlowTheme.of(context).secondaryBackground,
            shape: BoxShape.rectangle,
          ),
          child: Container(
            width: MediaQuery.of(context).size.width * 1.0,
            height: MediaQuery.of(context).size.height * 1.0,
            child: custom_widgets.VideoConferencePage(
              width: MediaQuery.of(context).size.width * 1.0,
              height: MediaQuery.of(context).size.height * 1.0,
              conferenceID: widget.conferenceID!,
              username: widget.username,
              useruid: widget.useruid!,
            ),
          ),
        ),
      ),
    );
  }
}
