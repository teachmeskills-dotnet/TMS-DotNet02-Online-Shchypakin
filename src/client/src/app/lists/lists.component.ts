import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MembershipSize } from '../_models/membershipSize';
import { MembershipType } from '../_models/membershipType';
import { MembershipTypeSize } from '../_models/membershipTypeSize';
import { MembershipService } from '../_services/membership.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  types: MembershipType[];
  sizes: MembershipSize[];
  assignForm: FormGroup;
  selectedType: MembershipType = {} as MembershipType;
  typeToUpdate: MembershipType = {} as MembershipType;
  typeToAdd: string;
  sizeToAdd: number;
  
  constructor(private membershipService: MembershipService, private toastr: ToastrService,
    private fb: FormBuilder) {
      this.initializeForm();
     }

  ngOnInit(): void {
    this.membershipService.getTypeSize().subscribe(typeSize => {
      this.types = typeSize.types;
      this.sizes = typeSize.sizes;
    });
  }

  initializeForm() {
    this.assignForm = new FormGroup({
      type: new FormControl(),
      size: new FormControl()       
    })
  }

  onTypeSelected() {
    this.typeToUpdate.id = this.selectedType.id;
    this.typeToUpdate.type = this.selectedType.type;
    console.log(this.typeToUpdate.id);
    
  }

  onTypeUpdate() {
    this.membershipService.updateType(this.typeToUpdate).subscribe(m => {
      this.toastr.success(`Тип изменен`) ;
    }), (e => {
      console.log(e);
    })
  }

  onTypeAdd() {
    this.membershipService.addType(this.typeToAdd).subscribe(t => {
      this.toastr.success(`Тип добавлен`) ;
    }), (e => {
      console.log(e);  
    })
  }

  onSizeAdd() {
    this.membershipService.addSize(this.sizeToAdd).subscribe(t => {
      this.toastr.success(`Количество посещений добавлено`) ;
    }), (e => {
      console.log(e); 

    })
  }
}
