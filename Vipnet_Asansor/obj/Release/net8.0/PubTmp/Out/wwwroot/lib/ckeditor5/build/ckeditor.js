// ckeditor.js
import ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import Essentials from '@ckeditor/ckeditor5-essentials/src/essentials';
import Paragraph from '@ckeditor/ckeditor5-paragraph/src/paragraph';
import Bold from '@ckeditor/ckeditor5-basic-styles/src/bold';
import Italic from '@ckeditor/ckeditor5-basic-styles/src/italic';
import Font from '@ckeditor/ckeditor5-font/src/font';
import Link from '@ckeditor/ckeditor5-link/src/link';
import Image from '@ckeditor/ckeditor5-image/src/image';
import List from '@ckeditor/ckeditor5-list/src/list';
import Table from '@ckeditor/ckeditor5-table/src/table';
import Alignment from '@ckeditor/ckeditor5-alignment/src/alignment';
import Emoji from '@ckeditor/ckeditor5-emoji/src/emoji';

ClassicEditor
    .create(document.querySelector('#editor'), {
        plugins: [
            Essentials, Paragraph, Bold, Italic, Font, Link, Image, List, Table, Alignment, Emoji
        ],
        toolbar: [
            'undo', 'redo', '|', 'bold', 'italic', '|',
            'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', '|',
            'link', 'imageUpload', 'numberedList', 'bulletedList', '|',
            'insertTable', 'alignment', 'emoji'
        ],
        table: {
            contentToolbar: ['tableColumn', 'tableRow', 'mergeTableCells']
        },
        alignment: {
            options: ['left', 'center', 'right', 'justify']
        }
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(error => {
        console.error(error);
    });


  