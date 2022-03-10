import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AppConsts } from '@shared/AppConsts';
import { OrganizationServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap';
import { CrudOrganizationComponent } from './crud/crud.component';

@Component({
	templateUrl: './organization.component.html',
	styleUrls: [
		'./organization.component.less'
	],
})
export class OrganizationComponent implements OnInit {

	list = [];

	constructor(
		private _organizationServiceProxy:OrganizationServiceProxy,
		private readonly _md: BsModalService,
		private _fb: FormBuilder,
	) {
	}

	ngOnInit() {
		this.getList();
	}

	private getList(){
		this._organizationServiceProxy.getList().subscribe(res => {
			this.list = res;
		})
	}

	openDialog(id?){
    
		var modal = this._md.show(CrudOrganizationComponent, {
		  keyboard: false,
		  class: 'md',
		  initialState: {
			title: id ? 'Cập nhật phòng ban' : 'Thêm phòng ban',
			id: id,
			isNew: id ? false : true
		  }
		});
	
		modal.content.onSave.subscribe(res => {
			this.getList();
		});
	}
}
