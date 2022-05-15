import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Membership } from '../_models/membership';
import { MembershipSize } from '../_models/membershipSize';
import { MembershipToSend } from '../_models/membershipToSend';
import { MembershipToUpdate } from '../_models/membershipToUpdate';
import { MembershipType } from '../_models/membershipType';
import { MembershipService } from '../_services/membership.service';

@Component({
  selector: 'app-edit-membership',
  templateUrl: './edit-membership.component.html',
  styleUrls: ['./edit-membership.component.css']
})
export class EditMembershipComponent implements OnInit {
  editForm: FormGroup;
  currentMemberId: number;
  types: MembershipType[];
  sizes: MembershipSize[];
  membership: MembershipToSend = {} as MembershipToSend;
  selectedMembership: Membership;
  membershipToUpdate: MembershipToUpdate;
  
  constructor(public modal: NgbActiveModal, private membershipService: MembershipService, 
    private toastr: ToastrService, private fb: FormBuilder) {}

  ngOnInit(): void {
    this.initializeForm();
    this.membershipService.getTypeSize().subscribe(typeSize => {
      this.types = typeSize.types;
      this.sizes = typeSize.sizes;
    })
  }

  onSaveClick() {
    this.membershipToUpdate = this.editForm.value;
    this.membershipToUpdate.online = this.editForm.value.online === 'true' ? true: false;
    this.membershipToUpdate.isActive = this.editForm.value.isActive === 'true' ? true: false;
    console.log(this.membershipToUpdate);
    this.membershipService.update(this.membershipToUpdate).subscribe(m => {
      this.selectedMembership = this.editForm.value;
      console.log(this.selectedMembership);
      this.toastr.success("Обновление успешно");
      this.editForm.reset(this.editForm.value);
      this.modal.close('Yes');
    })
  }

  initializeForm() {    
    this.editForm =  this.fb.group({
      id: [this.selectedMembership.id],
      start: [new Date(this.selectedMembership.start)],
      end: [new Date(this.selectedMembership.end)],
      online: [this.selectedMembership.online],
      membershipTypeId: [this.selectedMembership.membershipType.id],
      membershipSizeId: [this.selectedMembership.membershipSize.id],
      isActive: [this.selectedMembership.isActive]   
    })
  }

}
