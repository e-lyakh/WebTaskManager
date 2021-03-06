CREATE TABLE [TaskItem] (
	Id integer NOT NULL,
	Name varchar NOT NULL,
	List_Id integer NOT NULL,
	Order_In_List integer NOT NULL UNIQUE,
	Is_Favorite BIT NOT NULL DEFAULT '0',
	Description text,
	Creation_Date datetime NOT NULL,
	Delete_Date datetime NOT NULL,
	Schedule_Id integer NOT NULL,
	Priority_Id integer NOT NULL,
	Tag_Id integer NOT NULL,
	Status_Id integer NOT NULL,
	User_Id integer NOT NULL,
	Doer_Id integer NOT NULL,
  CONSTRAINT [PK_TASKITEM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskStatus] (
	Id integer NOT NULL,
	Name varchar(32) NOT NULL UNIQUE,
  CONSTRAINT [PK_TASKSTATUS] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskPriority] (
	Id integer NOT NULL,
	Name varchar(64) NOT NULL UNIQUE,
	Rank integer NOT NULL,
  CONSTRAINT [PK_TASKPRIORITY] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskFile] (
	Id integer NOT NULL,
	Name varchar(256) NOT NULL,
	Path varchar(256) NOT NULL,
	Guid varchar(256) NOT NULL UNIQUE,
	Attach_Date datetime NOT NULL,
	Task_Id integer NOT NULL,
  CONSTRAINT [PK_TASKFILE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User] (
	Id integer NOT NULL,
	Name varchar(64) NOT NULL,
	Last_Name varchar(64) NOT NULL,
	Login varchar(32) NOT NULL UNIQUE,
	Password varchar(256) NOT NULL,
	Email varchar(64) NOT NULL UNIQUE,
	Language varchar(64),
	Is_Email_Notified BIT DEFAULT '1',
	Registration_Date datetime NOT NULL,
	Last_Visit_Date datetime NOT NULL,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskSchedule] (
	Id integer NOT NULL,
	Start_Term datetime,
	End_Term datetime,
	Is_Reminder_On BIT DEFAULT '0',
	Reminder_Time datetime,
	RepeatTerm_Id integer NOT NULL DEFAULT '0',
  CONSTRAINT [PK_TASKSCHEDULE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskList] (
	Id integer NOT NULL,
	Name varchar(64) NOT NULL,
	Order_Rank integer NOT NULL UNIQUE,
	Color_R integer NOT NULL DEFAULT '255',
	Color_G integer NOT NULL DEFAULT '255',
	Color_B integer NOT NULL DEFAULT '255',
	User_Id integer NOT NULL,
	Filter_Id integer NOT NULL,
  CONSTRAINT [PK_TASKLIST] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Subtask] (
	Id integer NOT NULL,
	Name varchar NOT NULL,
	Order_In_List integer NOT NULL,
	Is_Completed BIT NOT NULL DEFAULT '0',
	Task_Id integer NOT NULL,
  CONSTRAINT [PK_SUBTASK] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Doer] (
	Id integer NOT NULL,
	Name varchar(64) NOT NULL,
	User_Id integer NOT NULL,
  CONSTRAINT [PK_DOER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [ListFilter] (
	Id integer NOT NULL,
	Is_Show_Completed BIT NOT NULL DEFAULT '1',
	Is_Ordered_Term BIT NOT NULL DEFAULT '0',
	Is_Ordered_Prior BIT NOT NULL DEFAULT '0',
	Is_Ordered_Tag BIT NOT NULL DEFAULT '0',
	Selected_From_Date date,
	Selected_To_Date date,
	Selected_Prior_Id integer,
	Selected_Tag_Id integer NOT NULL,
	Is_Only_Favorites BIT NOT NULL DEFAULT '0',
  CONSTRAINT [PK_LISTFILTER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [TaskTag] (
	Id integer NOT NULL,
	Name varchar(64) NOT NULL UNIQUE,
  CONSTRAINT [PK_TASKTAG] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [RepeatTerm] (
	Id integer NOT NULL,
	Repeat_Term varchar NOT NULL UNIQUE,
  CONSTRAINT [PK_REPEATTERM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk0] FOREIGN KEY ([List_Id]) REFERENCES [TaskList]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk0]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk1] FOREIGN KEY ([Schedule_Id]) REFERENCES [TaskSchedule]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk1]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk2] FOREIGN KEY ([Priority_Id]) REFERENCES [TaskPriority]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk2]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk3] FOREIGN KEY ([Tag_Id]) REFERENCES [TaskTag]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk3]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk4] FOREIGN KEY ([Status_Id]) REFERENCES [TaskStatus]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk4]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk5] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk5]
GO
ALTER TABLE [TaskItem] WITH CHECK ADD CONSTRAINT [TaskItem_fk6] FOREIGN KEY ([Doer_Id]) REFERENCES [Doer]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskItem] CHECK CONSTRAINT [TaskItem_fk6]
GO



ALTER TABLE [TaskFile] WITH CHECK ADD CONSTRAINT [TaskFile_fk0] FOREIGN KEY ([Task_Id]) REFERENCES [TaskItem]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskFile] CHECK CONSTRAINT [TaskFile_fk0]
GO


ALTER TABLE [TaskSchedule] WITH CHECK ADD CONSTRAINT [TaskSchedule_fk0] FOREIGN KEY ([RepeatTerm_Id]) REFERENCES [RepeatTerm]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskSchedule] CHECK CONSTRAINT [TaskSchedule_fk0]
GO

ALTER TABLE [TaskList] WITH CHECK ADD CONSTRAINT [TaskList_fk0] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id])
ON UPDATE NO ACTION
GO
ALTER TABLE [TaskList] CHECK CONSTRAINT [TaskList_fk0]
GO
ALTER TABLE [TaskList] WITH CHECK ADD CONSTRAINT [TaskList_fk1] FOREIGN KEY ([Filter_Id]) REFERENCES [ListFilter]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [TaskList] CHECK CONSTRAINT [TaskList_fk1]
GO

ALTER TABLE [Subtask] WITH CHECK ADD CONSTRAINT [Subtask_fk0] FOREIGN KEY ([Task_Id]) REFERENCES [TaskItem]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Subtask] CHECK CONSTRAINT [Subtask_fk0]
GO

ALTER TABLE [Doer] WITH CHECK ADD CONSTRAINT [Doer_fk0] FOREIGN KEY ([User_Id]) REFERENCES [User]([Id])
ON UPDATE NO ACTION
GO
ALTER TABLE [Doer] CHECK CONSTRAINT [Doer_fk0]
GO

ALTER TABLE [ListFilter] WITH CHECK ADD CONSTRAINT [ListFilter_fk0] FOREIGN KEY ([Selected_Prior_Id]) REFERENCES [TaskPriority]([Id])
ON UPDATE NO ACTION
GO
ALTER TABLE [ListFilter] CHECK CONSTRAINT [ListFilter_fk0]
GO
ALTER TABLE [ListFilter] WITH CHECK ADD CONSTRAINT [ListFilter_fk1] FOREIGN KEY ([Selected_Tag_Id]) REFERENCES [TaskTag]([Id])
ON UPDATE NO ACTION
GO
ALTER TABLE [ListFilter] CHECK CONSTRAINT [ListFilter_fk1]
GO



