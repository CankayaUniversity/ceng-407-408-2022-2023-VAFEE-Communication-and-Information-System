export interface Announcement {
    title: string;
    content: string;
    date: string;
}


export interface Course {
    code:string;
    name:string;
    instructors: string[];
    department: string;
    description: string;
    users: User[];
}
export interface User {
    id: string;
    name: string;
    email: string;
    displayName: string;
}


export interface Instructor {
    courses_taught: Course[];
    department: string;
    instructor_name: string;
    instructor_surname: string;
    uid: string;
}
export interface Todo { }
export interface Message { }


