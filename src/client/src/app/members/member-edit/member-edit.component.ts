import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/members';
import { MemberToSend } from 'src/app/_models/memberToSend';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  //@ViewChild('editForm') editForm: NgForm;
  editForm: FormGroup;
  selectedMember: Member;
  
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if(this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private memberService: MembersService, private toastr: ToastrService) {
    this.loadMember();
    this.initializeForm(); 
  }

  ngOnInit(): void {
    this.selectedMember.birthday = new Date(this.selectedMember.birthday)  ;
    this.editForm.reset(this.selectedMember);
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
    //this.editForm.value.id = this.selectedMember.id;
    //this.editForm.value.fullName = this.selectedMember.fullName;

  }

  loadMember() {
    this.selectedMember = JSON.parse(localStorage.getItem('member'));
  }

  updateMember() {
    const memberToSend :MemberToSend = {} as MemberToSend; 
    /*memberToSend.id = this.selectedMember.id;
    memberToSend.fullName = this.selectedMember.fullName;
    memberToSend.birthday = this.selectedMember.birthday;
    memberToSend.phoneNumber = this.selectedMember.phoneNumber;
    memberToSend.email = this.selectedMember.email;
    memberToSend.comment = this.selectedMember.comment;*/
    this.editForm.value.id = this.selectedMember.id;
    this.memberService.putMember(this.editForm.value).subscribe(m => {
      this.selectedMember = this.editForm.value;
      console.log(this.selectedMember);
      this.toastr.success("Обновление успешно");
      this.editForm.reset(this.editForm.value);
    })
    
  }

}
