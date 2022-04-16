import { Component, Input, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Membership } from '../_models/membership';
import { MembershipSize } from '../_models/membershipSize';
import { MembershipToSend } from '../_models/membershipToSend';
import { MembershipType } from '../_models/membershipType';
import { MembershipTypeSize } from '../_models/membershipTypeSize';
import { MembershipService } from '../_services/membership.service';

@Component({
  selector: 'app-assign-membership',
  templateUrl: './assign-membership.component.html',
  styleUrls: ['./assign-membership.component.css']
})
export class AssignMembershipComponent implements OnInit {
  types: MembershipType[];
  sizes: MembershipSize[];
  selectedTypeId: number;
  selectedSizeId: number;
  membership: MembershipToSend = {} as MembershipToSend;
  @Input() currentMemberId: number;

  constructor(private membershipService: MembershipService, private toastr: ToastrService) { 
    //this.setInitialValues();
  }

  ngOnInit(): void {
    this.setInitialValues();
    this.membershipService.getTypeSize().subscribe(typeSize => {
      this.types = typeSize.types;
      this.sizes = typeSize.sizes;
    })
  }

  onAddClick() {
    this.membership.clientId = this.currentMemberId;
    this.membershipService.postMembership(this.membership).subscribe(m => {
      this.toastr.success(`Абонемент назначен: ${new Date().toLocaleTimeString()}`) ;
    })
    console.log(this.membership.clientId);
    console.log(this.membership.start);
    console.log(this.membership.membershipSizeId);
    console.log(this.membership.membershipTypeId);
    console.log(this.membership.end);   
  }

  setInitialValues() {
    this.membership.clientId = this.currentMemberId;
    this.membership.start = new Date();
    this.membership.end = new Date();
    this.membership.membershipSizeId = 1;
    this.membership.membershipTypeId = 1;
  }

}
