import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Batch } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";
import { CommonService } from '../../shared/common.service'
import { UserProfile } from '../user/user.profile';

@Injectable()
export class BatchService {

    private _getBatchUrl = "/Batch/GetContacts";
    public url = this.commonService.getBaseMasterUrl() + '/Batch';
    public updateByIdUrl = this.commonService.getBaseMasterUrl() + '/Batch';
   // public _saveUrl: string = '/Course/SaveContact/';
    //public _updateUrl: string = '/Course/UpdateContact/';
    //  public _deleteByIdUrl: string = this.commonService.getBaseUrl() + '/Course/';

    constructor(private http: Http, private commonService: CommonService, private authProfile: UserProfile) { }



    getBatchs() {
        let url = this.commonService.getBaseMasterUrl() + '/batch';
      
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });
        //var getCoursesUrl = this._getCoursesUrl;
        return this.http.get(url, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }


    saveBatch(batch: Batch): Observable<string> {
        debugger;
        let body = JSON.stringify(batch);
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token,'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.url, body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    updateBatch(batch: Batch): Observable<string> {
        let body = JSON.stringify(batch);
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token,'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        
         return this.http.put(this.updateByIdUrl + '/' + batch.id , body, options)
            .map(res => res.json().message)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }

    //Delete Operation
    deleteBatch(id: number): Observable<string> {
        var deleteByIdUrl = this.url + '/' + id
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token,'Content-Type': 'application/json', 'Accept': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.delete(deleteByIdUrl)
            .map(response => response.json().message)
            .catch(this.handleError);
    }

 

}