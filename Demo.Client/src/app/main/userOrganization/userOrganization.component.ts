import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AppConsts } from '@shared/AppConsts';
import { OrganizationServiceProxy, UserOrganizationServiceProxy } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';
import { BsModalService } from 'ngx-bootstrap';
import { AddUserOrganizationComponent } from './addUserOrganization/addUserOrganization.component';
import { UpdateTitleUserOrganizationComponent } from './updateTitleUserOrganization/updateTitleUserOrganization.component';

@Component({
	templateUrl: './userOrganization.component.html',
	styleUrls: [
		'./userOrganization.component.less'
	],
})
export class UserOrganizationComponent implements OnInit {

	list = [];

	constructor(
		private _organizationServiceProxy:OrganizationServiceProxy,
		private _userOrganizationServiceProxy:UserOrganizationServiceProxy,
		private readonly _md: BsModalService,
		private _fb: FormBuilder,
	) {
	}

	ngOnInit() {
		this.getList();
	}

	addUserOrganization(organization){
		var modal = this._md.show(AddUserOrganizationComponent, {
			keyboard: false,
			class: 'md',
			initialState: {
				title: 'Thêm nhân viên',
				organization: _.cloneDeep(organization)
			}
		});
	
		modal.content.onSave.subscribe(res => {
			this.getList();
		});
	}

	updateTitleUserOrganization(organization, userOrganization){
		var modal = this._md.show(UpdateTitleUserOrganizationComponent, {
			keyboard: false,
			class: 'md',
			initialState: {
				title: 'Cập nhật chức danh',
				id: userOrganization.id,
				titleId: userOrganization.titleId,
				listTile: organization.titles ? JSON.parse(organization.titles) : []
			}
		});
	
		modal.content.onSave.subscribe(res => {
			this.getList();
		});
	}


	getUserOrganization(index){

		if(this.list[index].userOrganizations) return;

		this._userOrganizationServiceProxy.getListUserOrganizationByOrganizationId(this.list[index].id).subscribe(res => {
			this.list[index].userOrganizations = res;
		})
	}

	private getList(){
		this._organizationServiceProxy.getList().subscribe(res => {
			this.list = res;
		})
	}
}
