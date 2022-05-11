import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
  assignForm: FormGroup;
  types: MembershipType[];
  sizes: MembershipSize[];
  selectedTypeId: number;
  selectedSizeId: number;
  isOnline: boolean;
  membership: MembershipToSend = {} as MembershipToSend;
  @Input() currentMemberId: number;
  @Output() parentFun: EventEmitter<any> = new EventEmitter();

  constructor(private membershipService: MembershipService, private toastr: ToastrService,
    private fb: FormBuilder) { 
    this.initializeForm();
  }

  ngOnInit(): void {
    this.setInitialValues();
    this.membershipService.getTypeSize().subscribe(typeSize => {
      this.types = typeSize.types;
      this.sizes = typeSize.sizes;
    });
  }

  initializeForm() {
    this.assignForm = this.fb.group({
      clientId: [this.currentMemberId],
      start: [new Date(), Validators.required],
      end: [new Date(), Validators.required],
      online: [false],
      membershipTypeId: [1, Validators.required],
      membershipSizeId: [1, Validators.required]
      
    })
  }

  onAddClick() {
    //this.membership.clientId = this.currentMemberId;
    this.assignForm.value.clientId = this.currentMemberId;
    this.membership = this.assignForm.value;
    this.membership.online = this.assignForm.value.online === 'true' ? true: false;
    this.membershipService.postMembership(this.membership).subscribe(m => {
      this.toastr.success(`Абонемент назначен: ${new Date().toLocaleTimeString()}`) ;
      this.parentFun.emit();
    }), (e => {
      console.log(e);
    })

  }

  setInitialValues() {
    this.membership.clientId = this.currentMemberId;
    this.membership.start = new Date();
    this.membership.end = new Date();
    this.membership.membershipSizeId = 1;
    this.membership.membershipTypeId = 1;
  }

}
