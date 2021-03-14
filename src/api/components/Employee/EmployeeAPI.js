import BaseAPI from '@/api/base/BaseAPI.js';

class EmployeeAPI extends BaseAPI {
    constructor(){
        super();
        this.controler = "Employees";
    }
}

export default new EmployeeAPI();