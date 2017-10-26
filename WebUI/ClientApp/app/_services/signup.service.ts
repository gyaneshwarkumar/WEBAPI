import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Signup } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";
import { CommonService } from '../../shared/common.service'


@Injectable()
export class SignupService {

    private _getBatchUrl = "/Batch/GetContacts";
    public url = this.commonService.getBaseAuthUrl() + '/auth/register';
   
    constructor(private http: Http, private commonService: CommonService) { }
 
    saveSignup(signup: Signup): Observable<string> {
        let body = JSON.stringify(signup);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        var credentials = {
            email: signup.email,
            password: signup.password,
            confirmPassword: signup.confirmPassword
        };
        let url = this.commonService.getBaseAuthUrl() + '/auth/register';
        return this.http.post(url, credentials, options)
            .map((response: Response) => {
                return response.json();
            }).catch(this.commonService.handleFullError);
        //return this.http.post(this.url, body, options)
        //    .map(res => res.json().message)
        //    .catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }


}