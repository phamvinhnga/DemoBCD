import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AppConsts } from '@shared/AppConsts';
import { TitleServiceProxy } from '@shared/service-proxies/service-proxies';
import { BsModalService } from 'ngx-bootstrap';
import { CrudTitleComponent } from './crud/crud.component';

@Component({
	templateUrl: './title.component.html',
	styleUrls: [
		'./title.component.less'
	],
})
export class TitleComponent implements OnInit {

	list = [];

	constructor(
		private _titleServiceProxy:TitleServiceProxy,
		private _md: BsModalService,
		private _fb: FormBuilder,
	) {
	}

	ngOnInit() {
		this.getList();
	}

	private getList(){
		this._titleServiceProxy.getList().subscribe(res => {
			this.list = res;
		})
	}

	openDialog(id?){
    
		var modal = this._md.show(CrudTitleComponent, {
		  keyboard: false,
		  class: 'md',
		  initialState: {
			title: id ? 'Cập nhật chức danh' : 'Thêm chức danh',
			id: id,
			isNew: id ? false : true
		  }
		});
	
		modal.content.onSave.subscribe(res => {
			this.getList();
		});
	}
}
