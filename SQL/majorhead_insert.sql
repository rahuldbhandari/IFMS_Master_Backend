CREATE OR REPLACE PROCEDURE master.insert_majorhead(
	IN major_name text,
	IN major_coce text)
LANGUAGE 'plpgsql'
AS $BODY$
Begin


insert into master.major_head(name, code) values(major_name, major_coce);
commit;
end;
$BODY$;

call master.insert_majorhead('Major','002');
SELECT * FROM master.major_head;