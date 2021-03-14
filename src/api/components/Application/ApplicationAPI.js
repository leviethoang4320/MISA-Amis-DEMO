import BaseAPI from '@/api/base/BaseAPI.js';

class ApplicationAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "Applications";
    }
}

export default new ApplicationAPI();