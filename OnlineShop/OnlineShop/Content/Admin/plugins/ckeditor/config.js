/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Content/Admin/plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowserUrl = '/Content/Admin/plugins/ckfinder/ckfinder.html?Type = Images';
    config.filebrowserFlashBrowserUrl = '/Content/Admin/plugins/ckfinder/ckfinder.html?Type = Flash';
    config.filebrowserUploadUrl = '/Content/Admin/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=File';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Content/Admin/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor(null,'~/Content/Admin/plugins/ckfinder');
};
