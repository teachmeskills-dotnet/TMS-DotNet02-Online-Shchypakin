import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/members';
import { MemberToSend } from 'src/app/_models/memberToSend';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-user-edit-data',
  templateUrl: './user-edit-data.component.html',
  styleUrls: ['./user-edit-data.component.css']
})
export class UserEditDataComponent implements OnInit {
  editForm: FormGroup;
  user: Member;

  constructor(private memberService: MembersService, private toastr: ToastrService, public modal: NgbActiveModal) {
    this.initializeForm(); 
   }

  ngOnInit(): void {
    this.user.birthday = new Date(this.user.birthday)  ;
    this.editForm.reset(this.user);
  }

  initializeForm() {
    this.editForm = new FormGroup({
      id: new FormControl(),
      fullName: new FormControl(),
      birthday: new FormControl(),
      phoneNumber: new FormControl(),
      email: new FormControl(),
      comment: new FormControl()
    })
  }

  updateMember() {
    const memberToSend :MemberToSend = {} as MemberToSend; 
    this.editForm.value.id = this.user.id;
    this.editForm.value.comment = this.user.comment;
    this.memberService.putMember(this.editForm.value).subscribe(m => {
      this.user = this.editForm.value;
      console.log(this.user);
      this.toastr.success("Обновление успешно");
      this.editForm.reset(this.editForm.value);
      this.modal.close('Yes');
    })
    
  }
}
