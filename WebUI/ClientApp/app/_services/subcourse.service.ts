import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Subcourse } from '../_models/index';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";
import { CommonService } from '../../shared/common.service';
import { UserProfile } from '../user/user.profile'


@Injectable()
export class SubcourseService {

   
    public url = this.commonService.getBaseMasterUrl() + '/Subcourse';
   
    constructor(private http: Http, private commonService: CommonService, private authProfile: UserProfile) { }



    getSubcourses() {
        let url = this.commonService.getBaseMasterUrl() + '/Subcourse';
        let profile = this.authProfile.getProfile();
        let headers = new Headers({ 'Authorization': 'Bearer ' + profile.token });

        //var getCoursesUrl = this._getCoursesUrl;
        return this.http.get(url, { headers: headers })
            .map(response => <any>(<Response>response).json());
    }

 

    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }

  
}