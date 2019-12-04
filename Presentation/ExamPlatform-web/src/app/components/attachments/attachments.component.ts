import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AttachmentTypeService } from '../../services/attachmentType.service';
import { AttachmentType } from '../../models/AttachmentType';
import { NavbarService } from 'src/app/services/navbar.service';


@Component({
  selector: 'app-attachments',
  templateUrl: './attachments.component.html',
  styleUrls: ['./attachments.component.css']
})
export class AttachmentsComponent implements OnInit {
  selectedFile: File = null;
  attachmentTypes: Array<AttachmentType>;

  constructor(private http: HttpClient, public attachmentTypeService: AttachmentTypeService, public nav:NavbarService) { }

  ngOnInit() {
    this.getAttachmentTypes();
    this.nav.show();
  }

  onFileSelected(event) {
    this.selectedFile = <File>event.target.files[0];
    console.log(event);
    
  }
  private async getAttachmentTypes() {
    const response = await this.attachmentTypeService.getAttachmentTypes();
    this.attachmentTypes = response.data.attachmentTypes;
    console.log(this.attachmentTypes);

  }
  onUploadVideo(file: any) {
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post('localhost:4200/attachments', fd)
      .subscribe(res => {
        console.log(res)
      });
    console.log(file);

  }

  onUploadImage(file: any) {
    const fd = new FormData();
    fd.append('image', this.selectedFile, this.selectedFile.name);
    this.http.post('localhost:4200/attachments', fd)
      .subscribe(res => {
        console.log(res)
      });
    console.log(file);

  }

}
