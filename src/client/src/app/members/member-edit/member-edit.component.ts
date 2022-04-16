import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  @ViewChild('editForm') editForm: NgForm;
  selectedMember: Member;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if(this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(private memberService: MembersService, private toastr: ToastrService) {
    this.loadMember();
  }

  ngOnInit(): void {
    
  }

  loadMember() {
    this.selectedMember = JSON.parse(localStorage.getItem('member'));
  }

  updateMember() {
    const memberToSend :MemberToSend = {} as MemberToSend; 
    memberToSend.id = this.selectedMember.id;
    memberToSend.fullName = this.selectedMember.fullName;
    memberToSend.birthday = this.selectedMember.birthday;
    memberToSend.phoneNumber = this.selectedMember.phoneNumber;
    memberToSend.email = this.selectedMember.email;
    memberToSend.comment = this.selectedMember.comment;
    this.memberService.putMember(memberToSend).subscribe(m => {
      console.log(this.selectedMember);
      this.toastr.success("Обновление успешно");
      this.editForm.reset(this.selectedMember);
    })
    
  }

}
