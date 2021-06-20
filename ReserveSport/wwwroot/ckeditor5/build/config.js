
ClassicEditor
    .create(document.querySelector('.Texteditor'), {
        toolbar: {
            items: [
                'heading',
                '|',
                'bold',
                'italic',
                'link',
                '|',
                'fontSize',
                'fontColor',
                '|',
                'imageUpload',
                'blockQuote',
                'insertTable',
                'undo',
                'redo',
                'codeBlock'
            ]
        },
        language: 'fa',
        table: {
            contentToolbar: [
                'tableColumn',
                'tableRow',
                'mergeTableCells'
            ]
        },
        licenseKey: '',
        simpleUpload: {
            // The URL that the images are uploaded to.
            uploadUrl: '/up-img-new'
        }

    })
    .then(editor => {
        window.editor = editor;




    })
    .catch(error => {
        console.error(error);
    });