create table Human
(
    id        int auto_increment
        primary key,
    name      varchar(100) not null,
    is_active tinyint(1)   not null
);

create table Document_Type
(
    id        int auto_increment
        primary key,
    name      varchar(100) not null,
    is_active tinyint(1)   not null
);

create table File
(
    id   int auto_increment
        primary key,
    name varchar(50)  not null,
    path varchar(100) not null
);

create table Document
(
    id              int auto_increment
        primary key,
    name            varchar(100) not null,
    create_date     date         not null,
    id_type         int          not null,
    annotation      varchar(100) not null,
    id_author       int          not null,
    id_responsible  int          not null,
    expiration_date date         not null,
    is_active       tinyint(1)   not null,
    constraint Document_Document_Type_id_fk
        foreign key (id_type) references Document_Type (id),
    constraint Document_Human_id_fk
        foreign key (id_author) references Human (id),
    constraint Document_Human_id_fk_2
        foreign key (id_responsible) references Human (id)
);

create table Document_Files
(
    id          int auto_increment
        primary key,
    id_document int not null,
    id_file     int not null,
    constraint Document_Files_Document_id_fk
        foreign key (id_document) references Document (id),
    constraint Document_Files_File_id_fk
        foreign key (id_file) references File (id)
);


create table History
(
    id          int auto_increment
        primary key,
    id_document int          not null,
    date        datetime     not null,
    comment     varchar(100) not null,
    constraint History_Document_id_fk
        foreign key (id_document) references Document (id)
);
